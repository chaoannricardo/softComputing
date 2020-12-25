﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R08546036SHChaoAss12
{
    class BbackPropagationMLP
    {
        #region variables
        float[][] x; // neuron values 
        Point[][] pts;
        float[][][] w; // weights 
        float[][] e; // epsilon; partial derivative of error with respect to net value. 

        int[] n; // numbers of neuron on layers
        int inputDimension; // dimension of input vector 
        int inputNumber; // number of instances on the data set 
        int numberOfTrainningVectors; // number of instances that are serving as training data 
        float[,] originalInputs; // original instances of input vectors (without normalization) 
        float[,] inputs; // normalized input vectors 
        float[] inputMax; // upper bounds on all components of input vectors 
        float[] inputMin; // lower bounds on all components of input vectors 
        int inputWidth; // dimension in width for a two-dimensional input vector 

        int targetDimension; // dimension of target vector 
        float[,] originalTargets; // original instances of target vectors (without normalization) 
        float[,] targets; // normalized target vectors 
        float[] targetMax; // upper bounds on all components of target vectors 
        float[] targetMin; // lower bounds on all components of target vectors. 

        int[] vectorIndices; // array of shuffled indices of data instances; the front portion is training vectors; 
                             //the rear portion is testing vectors 
        float rootMeanSquareError = 0.0f; // root mean square of error for an epoch of data training 
        int layerNumber; // number of neuron layer (including the input layer) 

        Random randomizer = new Random();

        float learningRate = 0.999f; // learning rate, specified by the user 

        // variables defined 
        int neuronNums;
        int trainingLimit = 100;
        int iterationCount = 0;
        float trainingRatio = 0.0F;
        bool isReset = false;
        #endregion


        #region properties
        /// <summary> 
        /// The factor of reducing the eta epoch by epoch. That is 
        /// eta <-- LearningRate * eta 
        /// </summary> 
        public float LearningRate
        {
            get { return learningRate; }
            set { learningRate = value; }
        }

        float eta; // step size that specify the update amount on each weight 
        float initialEta = 0.7f; // initial step size, specified by the user 

        /// <summary> 
        /// Initialize variable of the eta (can be regarded as step size). 
        /// </summary> 
        public float InitialEta
        {
            set { initialEta = value; }
            get { return initialEta; }
        }

        /// <summary> 
        /// Current root mean square after an epoch training. 
        /// </summary> 
        public float RootMeanSquareError
        {
            get { return rootMeanSquareError; } 
        }

        public int[] NeuronNumbers { get => n; }
        public int TrainingLimit { get => trainingLimit; set => trainingLimit = value; }
        public float[][][] Weight { get => w; }
        public float[][] NeuronValue { get => x; }
        public float TrainingRatio { get => trainingRatio; set => trainingRatio = value; }
        public int IterationCount { get => iterationCount;}
        public bool IsReset { get => isReset;}
        public float[][] Epilson { get => e;}


        #endregion

        public BbackPropagationMLP(int hiddenLayerNum, int neuronNums)
        {
            this.layerNumber = (hiddenLayerNum + 2);
            this.neuronNums = neuronNums;
        }

        #region other method
        /// <summary> 
        /// Read in the data set from the given file stream. Configure the portions of training 
        /// and testing data subsets. Original data are stored, bounds on each component of 
        /// input vector and target vector are founds, and normalized data set is prepared. 
        /// </summary> 
        /// <param name="sr">file stream</param> 
        /// <param name="trainingRatio">portion of trainning data</param> 
        public void ReadInDataSet(StreamReader sr, float trainingRatio)
        {
            char[] separators = new char[] { ',', ' ' };
            string s = sr.ReadLine();
            string[] items = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            inputNumber = Convert.ToInt32(items[0]);
            inputDimension = Convert.ToInt32(items[1]);
            targetDimension = Convert.ToInt32(items[2]);
            inputWidth = Convert.ToInt32(items[3]);

            // add something in following part

            this.trainingRatio = trainingRatio;

            // initiate vars
            inputMax = new float[inputDimension];
            inputMin = new float[inputDimension];
            targetMax = new float[targetDimension];
            targetMin = new float[targetDimension];

            // check numbers of data rows and variables
            originalInputs = new float[inputNumber, inputDimension];
            inputs = new float[inputNumber, inputDimension];
            originalTargets = new float[inputNumber, targetDimension];
            targets = new float[inputNumber, targetDimension];

            // read in data
            for (int i = 0; i < inputNumber; i++)
            {
                items = sr.ReadLine().Split(',');
                for (int j = 0; j < (inputDimension + targetDimension); j++)
                {
                    if (j < inputDimension)
                    {
                        // input section

                        // intiate upper and lower bound if first iteration
                        if (i == 0)
                        {
                            inputMax[j] = float.MinValue;
                            inputMin[j] = float.MaxValue;
                        }

                        originalInputs[i, j] = Convert.ToSingle(items[j]);
                        if (Convert.ToSingle(items[j]) > inputMax[j]) inputMax[j] = Convert.ToSingle(items[j]);
                        if (Convert.ToSingle(items[j]) < inputMin[j]) inputMin[j] = Convert.ToSingle(items[j]);
                    }
                    else
                    {
                        // target section

                        // initiate upper and lower bound if first iteration
                        if (i == 0)
                        {
                            targetMax[j - inputDimension] = float.MinValue;
                            targetMin[j - inputDimension] = float.MaxValue;
                        }

                        originalTargets[i, (j - inputDimension)] = Convert.ToSingle(items[j]);
                    }
                }
            }

            // normalization
            for (int i = 0; i < inputNumber; i++)
            {
                for (int j = 0; j < (inputDimension + targetDimension); j++)
                {

                    if (j < inputDimension)
                    {
                        inputs[i, j] = (originalInputs[i, j] - inputMin[j]) / (inputMax[j] - inputMin[j]);
                    }
                    else
                    {
                        targets[i, (j - inputDimension)] = (originalTargets[i, (j - inputDimension)]) /
                                (targetMax[j - inputDimension] - targetMin[j - inputDimension]);
                    }

                }
            }


        }


        /// <summary> 
        /// Configure the topology of the NN with the user specified numbers of hidden 
        /// neuorns and layers. 
        /// </summary> 
        /// <param name="hiddenNeuronNumbers">list of numbers of neurons of hidden layers</param> 
        public void ConfigureNeuralNetwork(int[] hiddenNeuronNumbers)
        {
            // add something - finished
            layerNumber = hiddenNeuronNumbers.Length + 2;
            n = new int[layerNumber];
            n[0] = inputDimension + 1;

            n[layerNumber - 1] = targetDimension + 1;

            for (int i = 1; i < (layerNumber - 1); i++)
            {
                n[i] = hiddenNeuronNumbers[i - 1] + 1;
            }

            pts = new Point[layerNumber][];
            for (int l = 0; layerNumber < pts.Length; l++)
            {
                pts[l] = new Point[n[l]];
            }
        }


        /// <summary> 
        /// Randomly shuffle the orders of the data in the data set. 
        /// </summary> 
        private void RandomizeIndices()
        {
            // add something

            // assign input & target to temp array
            float[,] tempInput = inputs;
            float[,] tempTarget = targets;

            int[] indices = new int[inputNumber];

            // initiate array with indices value and randomize indices
            for (int i = 0; i < inputNumber; i++)
            {
                indices[i] = i;
            }
            indices = indices.OrderBy(x => randomizer.Next()).ToArray();

            // assign new value to input
            for (int i = 0; i < indices.Length; i++)
            {
                // reassign random normalized input
                for (int j = 0; j < inputDimension; j++)
                {
                    inputs[i, j] = tempInput[indices[i], j];
                }
                // reassign random normalized target
                for (int j = 0; j < targetDimension; j++)
                {
                    targets[i, j] = tempTarget[indices[i], j];
                }
            }

            tempInput = originalInputs;
            tempTarget = originalTargets;
            // assign new value to original input
            for (int i = 0; i < indices.Length; i++)
            {
                // reassign random normalized input
                for (int j = 0; j < inputDimension; j++)
                {
                    originalInputs[i, j] = tempInput[indices[i], j];
                }
                // reassign random normalized target
                for (int j = 0; j < targetDimension; j++)
                {
                    originalTargets[i, j] = tempTarget[indices[i], j];
                }
            }

        }


        /// <summary> 
        /// Randomly set values of weights between [-1,1] and randomly shuffle the orders of all 
        /// the datum in the data set. Reset value of initial eta and root mean square to 0.0. 
        /// </summary> 
        public void ResetWeightsAndInitialCondition()
        {
            // add something

            // random the indices
            RandomizeIndices();

            // initiate weight: layerNum, toWhichNode, fromWhichNode
            w = new float[layerNumber][][];

            for (int i = 0; i < layerNumber; i++)
            {
                if (i != 0)
                {

                    w[i] = new float[n[i]][];

                    for (int j = 0; j < n[i]; j++)
                    {

                        w[i][j] = new float[n[i - 1]];

                        for (int l = 0; l < n[i - 1]; l++)
                        {

                            w[i][j][l] = 0.4F;

                        }
                    }
                }

            }

            // initate neuron value & epsilon
            x = new float[layerNumber][];
            e = new float[layerNumber][];

            for (int i = 0; i < layerNumber; i++)
            {
                x[i] = new float[n[i]];
                e[i] = new float[n[i]];
            }

            // set amount for training
            numberOfTrainningVectors = (int) Math.Round(inputNumber * trainingRatio);

            // other stuff
            iterationCount = 0;
            isReset = true;
            eta = initialEta;

        }

        /// <summary> 
        /// Sequentially loop through each training datum of the training data whose indices are 
        /// randomly shuffled in vectorIndices[] array, to perform on-line training of the NN. 
        /// </summary> 
        public void TrainAnEpoch()
        {
            float v;
            float errorSquareSum = 0.0f;
            float sumation = 0.0f;
            float updateAmount = 0.0f;
            int layerNumberMinusOne = layerNumber - 1;

            /// forward computing for all neuro values. 
            // add something numberOfTrainningVectors

            for (int sample = 0; sample < numberOfTrainningVectors; sample++)
            {
                // clear all value in neurons
                for (int i = 0; i < layerNumber; i++)
                {
                    for (int j = 0; j < n[i]; j++)
                    {
                        x[i][j] = 0.0F;
                        e[i][j] = 0.0F;
                    }
                }

                // set neurons in first layer
                for (int i = 0; i < n[0]; i++)
                {
                    if (i == 0)
                    {
                        // bias section
                        x[0][i] = 1;
                    }
                    else
                    {
                        x[0][i] = inputs[sample, i - 1];
                    }
                }

                // calculate value of other neurons
                // note: weight: layerNum, toWhichNode, fromWhichNode
                for (int i = 0; i < (layerNumber - 1); i++)
                {
                    // calculate vertice value
                    for (int j = 0; j < n[i]; j++)
                    {
                        for (int l = 0; l < n[i + 1]; l++)
                        {
                            if (l == 0)
                            {
                                // bias section
                                x[i + 1][l] = 1;
                            }
                            else
                            {
                                x[i + 1][l] += (w[i + 1][l][j] * x[i][j]);
                            }
                        }

                    }

                    // apply sigmoidal function
                    for (int j = 1; j < n[i + 1]; j++)
                    {
                        x[i + 1][j] = Convert.ToSingle(1 / (1 + Math.Exp(-x[i + 1][j])));
                    }


                }

                // compute the epsilon values for neurons on the output layer
                // and error square sum
                // add something
                for (int i = 0; i < targetDimension; i++)
                {
                    e[(layerNumber) - 1][i + 1] = (-2) * ((targets[sample, i] - x[(layerNumber) - 1][i + 1]))
                        * (1 - x[(layerNumber) - 1][i + 1]);

                    errorSquareSum += (((targets[sample, i] - x[(layerNumber) - 1][i + 1])) *
                        ((targets[sample, i] - x[(layerNumber) - 1][i + 1])));
                }

                /// backward computing for the epsilon values 
                /// // add something
                /// 
                for (int i = (layerNumber - 2); i >= 0; i--) {

                    for (int j = 0; j < n[i]; j++) {

                        // comput epsilon from backward
                        // Note: weight: layerNum, toWhichNode, fromWhichNode

                        // use sumation as temperory variable keeping
                        sumation = 0.0F;

                        for (int l = 0; l < n[i + 1]; l++) {
                            sumation += (w[i + 1][l][j] * e[i+1][l]);
                        }


                        e[i][j] = x[i][j] * (1 - x[i][j]) * sumation;


                    }
                
                }


                /// update weights for all weights by using epsilon and neuron values. 
                // add something
                for (int i = 0; i < (layerNumber - 1); i++)
                {
                    if (i != 0)
                    {
                        for (int j = 0; j < n[i]; j++)
                        {
                            for (int l = 0; l < n[i - 1]; l++)
                            {
                                updateAmount = (-eta) * e[i][j] * x[i - 1][l];

                                w[i][j][l] += updateAmount;
                            }
                        }
                    }
                }


            }

            // calculate error term


            rootMeanSquareError = Convert.ToSingle(Math.Sqrt(errorSquareSum / (targetDimension * numberOfTrainningVectors)));

            /// update step size of the updating amount 
            // add something

            eta *= learningRate;

            iterationCount += 1;

        }

        /// <summary> 
        /// Compute the output vector for an input vector. Both vectors are in the raw 
        /// format. The input vector is subject to scaling first before forward computing. 
        /// Output vector is then scaled back to raw format for recognition. 
        /// </summary> 
        /// <param name="input">input vector in raw format</param> 
        /// <returns>output vector in raw format</returns> 
        public float[] ComputeResults(float[] input)
        {
            float[] results = null;
            float v;
            results = new float[targetDimension];

            // add something


            return results;
        }

        /// <summary> 
        /// If the data set is a classification data set, test the data to generate confusing table. 
        /// The index of the largest component of the target vector is the targeted class id. 
        /// The index of the largest component of the computed output vector is the resulting class id. 
        /// If both the targeted class id and the resulting class id are the same, then the test 
        /// data is correctly classified. 
        /// </summary> 
        /// <param name="confusingTable">generated confusing table</param> 
        /// <returns>the ratio between the number of correctly classified testing data and the total number of testing data.</returns> 
        public float TestingClassification(out int[,] confusingTable)
        {
            confusingTable = new int[targetDimension, targetDimension];

            int successedCount = 0;

            float v;


            // add something




            return (float)successedCount / (float)(inputNumber - numberOfTrainningVectors);
        }

        public void DrawMLP(Graphics g, Rectangle bound)
        {
            if (n == null) return;
            int dw = bound.Width / pts.Length;
            int woff = dw / 2;
            Rectangle rect = Rectangle.Empty;
            int halfUnit = bound.Height / 30;
            rect.Width = rect.Height = halfUnit + halfUnit;

            for (int l = 0; l < pts.Length; l++)
            {
                int dh = bound.Height / n[l];
                int hoff = dh / 2;

                for (int c = 0; c < n[l]; c++)
                {
                    pts[l][c].X = woff + l * dw;
                    pts[l][c].Y = hoff + c * dh;

                    rect.X = pts[l][c].X - halfUnit;
                    rect.Y = pts[l][c].Y - halfUnit;

                    g.DrawRectangle(Pens.Red, rect);


                }


            }

            ResetWeightsAndInitialCondition();


        }
        #endregion


    }
}
