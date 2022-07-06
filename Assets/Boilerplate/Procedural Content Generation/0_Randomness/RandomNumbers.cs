using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(Renderer))]
public class RandomNumbers : MonoBehaviour
{
	[Header("Probability Table")]
	public int[] m_ProbabilityTable = { 60, 30, 10 };

	private int m_TotalWeight;
	private System.Random _Rnd = new System.Random();
	private Renderer _Renderer; 

	private void Awake()
    {
		_Renderer = GetComponent<Renderer>();

		StartProbabilityTable();
	}

    void Start()
    {
		//Fibonacci(0, 1);
		//Fibonacci(8, 14);

		/* Pseudo random */
		//MiddleSquareGrayScale(10, 5234567890);
		//MiddleSquareGrayScale(1000, 1234567890);
		//MiddleSquareGrayScale(30000, 1234567890); //Warning: The random number stops working!

		//LinearCongruentialGrayScale(10, 6);
		//LinearCongruentialGrayScale(30000, 100);
		//LinearCongruentialGrayScale(60000, 5234567890);

		//UnityRandom01(10, 77);
		//UnityRandomGrayScale(10, 77);
		UnityRandomGrayScale(1000, 77);
		//UnityRandomProbabilityTable(12345);


		/* System Random method */
		//SystemRandom01(10);
		//SystemRandom01(100);
		//SystemRandom01(1000);

		//SystemRandomGrayScale(10);
		//SystemRandomGrayScale(100);
		//SystemRandomGrayScale(30000);

		//SystemRandomProbabilityTable();
	}

	//Generate random numbers with the Fibonacci series
	private void Fibonacci(int xMinusOneSeed, int xMinusTwoSeed)
	{
		int xMinusOne = xMinusOneSeed;

		int xMinusTwo = xMinusTwoSeed;

		//The Fibonacci series is endless so we have to limit by using a modulus
		int m = int.MaxValue;

		string allRandomNumbers = "";

		for (int i = 0; i < 100; i++)
		{
			//x_n = x_(n-1) + x_(n-2)

			//Numbers in C# wrap, so if the sum is larger than the possible value, it begins
			//from the smallest possible value, so we have to check if the sum is < 0
			int sum = xMinusOne + xMinusTwo;

			if (xMinusOne + xMinusTwo < 0)
			{
				sum = int.MaxValue;
			}

			int randomNumber = sum % m;

			allRandomNumbers += randomNumber.ToString() + " | ";

			xMinusTwo = xMinusOne;
			xMinusOne = randomNumber;
		}

		print(allRandomNumbers);
	}


	//Generate random numbers with the Middle Square Method ( https://www.youtube.com/watch?v=4sYawx70iP4&index=2 )
	void MiddleSquareGrayScale(int amountOfNumbers, long seed)
	{
		/*
		For seed we cant use the regular int32, which max value is 2147483647
		So we have to use long, which max value is 9,223,372,036,854,775,807
		Seed for testing: 5234567890
		*/

		//How many digits in the seed?
		int digits = seed.ToString().Length;

		//To display the random numbers when the loop is finished
		string allRandomNumbers = "";

		//Array that will store the random numbers so we can display them
		float[] randomNumbers = new float[amountOfNumbers];

		for (int i = 0; i < amountOfNumbers; i++)
		{
			//Square the seed
			long seedSqr = seed * seed;

			//Make it a string
			string randomString = seedSqr.ToString();

			//If the string has less than digits * 2 characters, add zeros to the front of the string
			while (randomString.Length < digits * 2)
			{
				randomString = 0 + randomString;
			}

			//Get the middle characters of this string
			int start = Mathf.FloorToInt(digits / 2);

			string middleCharacters = randomString.Substring(start, digits);

			//The next seed in the next loop is these middle characters
			seed = long.Parse(middleCharacters);

			//If we want a float between 0 and 1 we divide the maximum number with 9999 if we have 4 digits
			float divisor = (Mathf.Pow(10f, digits)) - 1f;


			//allRandomNumbers += (seed / divisor) + " | "; // Comment this line if you want to speed up the testing of the algorithm

			randomNumbers[i] = seed / divisor;
		}

		print(allRandomNumbers);

		DrawRandomMapGrayScale(randomNumbers);
	}

	//Generate random numbers with the Linear Congruential Generator
	void LinearCongruentialGrayScale(int amountOfNumbers, long seed)
	{
		/* 
		Needs the following parameters, which can be found on Wikipedia for different implementations 
		( https://en.wikipedia.org/wiki/Linear_congruential_generator )
		*/

		//multiplier
		long a = 1103515245;
		//increment
		long c = 12345;
		//modulus m (which is also the maximum possible random value)
		long m = (long)Mathf.Pow(2f, 31f);

		//To display the random numbers when the loop is finished
		string allRandomNumbers = "";

		//Array that will store the random numbers so we can display them
		float[] randomNumbers = new float[amountOfNumbers];

		for (int i = 0; i < amountOfNumbers; i++)
		{
			//Basic idea: seed = (a * seed + c) mod m
			seed = (a * seed + c) % m;

			//To get a value between 0 and 1
			float randomValue = seed / (float)m;

			//allRandomNumbers += randomValue + " | "; //Comment this line if you want to speed up the testing of the algorithm

			randomNumbers[i] = randomValue;
		}


		print(allRandomNumbers);

		DrawRandomMapGrayScale(randomNumbers);
	}

	void SystemRandom01(int amountOfNumbers) 
	{
		string allRandomNumbers = "";

		float[] randomNumbers = new float[amountOfNumbers];

		for (int i = 0; i < amountOfNumbers; i++)
		{
			/* Perform arithmetic in double type to avoid overflowing */
			double range = (double)float.MaxValue - (double)float.MinValue;
			double sample = _Rnd.NextDouble();
			double scaled = (sample * range) + float.MinValue;

			float randomValue = (float)scaled; // This value will be near float.MaxValue or float.MinValue, so we always get a number under 0.0f or higher than 1.0f

			allRandomNumbers += randomValue + " | ";

			randomNumbers[i] = randomValue;
		}

		print(allRandomNumbers);

		DrawRandomMapGrayScale(randomNumbers);
	}

	void SystemRandomGrayScale(int amountOfNumbers)
	{
		string allRandomNumbers = ""; 

		float[] randomNumbers = new float[amountOfNumbers];

		for (int i = 0; i < amountOfNumbers; i++)
		{
			float randomValue = (float)_Rnd.Next(0, 101) / 100.0f; //Get a value from 0.0f to 1.0f

			allRandomNumbers += randomValue + " | ";

			randomNumbers[i] = randomValue;
		}

		print(allRandomNumbers);

		DrawRandomMapGrayScale(randomNumbers);
	}

	void SystemRandomProbabilityTable() 
	{
		//To display the random numbers when the loop is finished
		string allRandomNumbers = "";

		//Array that will store the random numbers so we can display them
		float[] randomNumbers = new float[m_TotalWeight];

		for (int i = 0; i < m_TotalWeight; i++)
		{

			int randomValue = _Rnd.Next(1, m_TotalWeight + 1);

			//Remove this line if you want to speed up the testing of the algorithm
			//allRandomNumbers += randomValue + " ";
			int tableValue = CheckTable(randomValue);

			randomNumbers[i] = tableValue;
		}

		print(allRandomNumbers);

		DrawRandomMapRGB(randomNumbers);
	}

	void UnityRandom01(int amountOfNumbers, int seed)
	{
		Random.InitState(seed);

		string allRandomNumbers = "";

		float[] randomNumbers = new float[amountOfNumbers];

		for (int i = 0; i < amountOfNumbers; i++)
		{
			/* Perform arithmetic in double type to avoid overflowing */
			double range = (double)float.MaxValue - (double)float.MinValue;
			double sample = UnityEngine.Random.Range(0.0f, 1.0f);
			double scaled = (sample * range) + float.MinValue;

			float randomValue = (float)scaled; // This value will be near float.MaxValue or float.MinValue, so we always get a number under 0.0f or higher than 1.0f

			//allRandomNumbers += randomValue + " | ";

			randomNumbers[i] = randomValue;
		}

		print(allRandomNumbers);

		DrawRandomMapGrayScale(randomNumbers);
	}

	void UnityRandomGrayScale(int amountOfNumbers, int seed)
	{
		Random.InitState(seed);
		string allRandomNumbers = "";

		float[] randomNumbers = new float[amountOfNumbers];

		for (int i = 0; i < amountOfNumbers; i++)
		{
			float randomValue = UnityEngine.Random.Range(0.0f, 1.0f); 

			//allRandomNumbers += randomValue + " | ";

			randomNumbers[i] = randomValue;
		}

		print(allRandomNumbers);

		DrawRandomMapGrayScale(randomNumbers);
	}

	void UnityRandomProbabilityTable(int seed)
	{
		Random.InitState(seed);

		string allRandomNumbers = "";

		float[] randomNumbers = new float[m_TotalWeight];

		for (int i = 0; i < m_TotalWeight; i++)
		{

			int randomValue = UnityEngine.Random.Range(1, m_TotalWeight + 1);

			//allRandomNumbers += randomValue + " | "; //Comment this line if you want to speed up the testing of the algorithm
			int tableValue = CheckTable(randomValue);

			randomNumbers[i] = tableValue;
		}

		print(allRandomNumbers);

		DrawRandomMapRGB(randomNumbers);
	}



	#region Probability table
	private void StartProbabilityTable() 
	{
        //Tally the total weight
        foreach (int weight in m_ProbabilityTable)
        {
			m_TotalWeight += weight;
        }

		//print("Total weight: " + m_Total);
	}

	private int CheckTable(int randomNumber) 
	{
        for (int i = 0; i < m_ProbabilityTable.Length; i++)
        {
			if (randomNumber <= m_ProbabilityTable[i]) // Table values must be in descendent order!
			{
				//Debug.Log("Probability table slot: " + i);
				return i;
			}
            else
            {
				randomNumber -= m_ProbabilityTable[i];
            }
		}
		return -1;
	}

    #endregion

    #region Draw Map
    void DrawRandomMapRGB(float[] randomValues)
	{
		//The random values are 1D, but we want to display them in a square
		int width = Mathf.FloorToInt(Mathf.Sqrt(randomValues.Length));

		//From random values to colors
		Color[] colorMap = new Color[width * width];

		for (int x = 0; x < width * width; x++)
		{

			switch (randomValues[x])
			{
				case 0:
					colorMap[x] = Color.red;
					break;

				case 1:
					colorMap[x] = Color.green;
					break;

				case 2:
					colorMap[x] = Color.blue;
					break;

				case 3:
					colorMap[x] = Color.cyan;
					break;

				case 4:
					colorMap[x] = Color.yellow;
					break;

				case 5:
					colorMap[x] = Color.white;
					break;

				case 6:
					colorMap[x] = Color.black;
					break;

				default:
					//Fail
					colorMap[x] = Color.magenta;
					break;
			}

		}

		//Add the colors to the texture
		Texture2D texture = new Texture2D(width, width);

		texture.SetPixels(colorMap);

		//Remove the blur from the texture
		texture.filterMode = FilterMode.Point;

		texture.wrapMode = TextureWrapMode.Clamp;

		texture.Apply();

		//Add the texture to the material
		_Renderer.material.mainTexture = texture;
	}

	void DrawRandomMapGrayScale(float[] randomValues) // Draw from 0.0f (white) to 1.0f (black) values
	{
		//The random values are 1D, but we want to display them in a square
		int width = Mathf.FloorToInt(Mathf.Sqrt(randomValues.Length));

		//From random values to colors
		Color[] colorMap = new Color[width * width];

		for (int x = 0; x < width * width; x++)
		{
			//The colors are gray scale
			colorMap[x] = Color.Lerp(Color.black, Color.white, randomValues[x]);
		}

		//Add the colors to the texture
		Texture2D texture = new Texture2D(width, width);

		texture.SetPixels(colorMap);

		//Remove the blur from the texture
		texture.filterMode = FilterMode.Point;

		texture.wrapMode = TextureWrapMode.Clamp;

		texture.Apply();

		//Add the texture to the material
		_Renderer.material.mainTexture = texture;
	}
	#endregion
}
