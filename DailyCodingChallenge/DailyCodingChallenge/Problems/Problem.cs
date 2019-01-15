using System;
using System.Collections.Generic;
using System.Linq;

// A generic problem. It contains its number and its description.
public abstract class Problem
{
	#region Static region

	// Dictionary containing pairs (problem_number, problem_type) used for dinamically initialization.
	private static Dictionary<int, Type> _problems;

	// Creating and initialising the dictionary
	static Problem()
	{
		Problem problem;
		_problems = new Dictionary<int, Type>();
		
		// Using reflection to extract from the assembies all the subtypes of the class "Problem"
		var types = from assembly in AppDomain.CurrentDomain.GetAssemblies()
					from type in assembly.GetTypes()
					where type.IsSubclassOf(typeof(Problem)) && !type.IsAbstract
					select type;
		foreach (Type t in types)
		{
			problem = (Problem)Activator.CreateInstance(t);
			_problems.Add(problem.ProblemNumber, t);
		}
	}

	public static List<Type> GetProblemTypes() => _problems.Values.ToList();

	public static Problem GetProblem(int problemNumber)
	{
		Problem problem = null;
		if (_problems.ContainsKey(problemNumber))
			problem = (Problem)Activator.CreateInstance(_problems[problemNumber]);
		return problem;
	}

	#endregion

	#region Private members

	private int _problemNumber;
	private string _description;

	#endregion

	#region Constructor

	protected Problem(int problemNumber, string description)
	{
		if (problemNumber <= 0)
			new ArgumentOutOfRangeException("Not-positive numbers are not ammitted!");
		if (null == description)
			new ArgumentNullException("Null description is not ammitted!");
		_problemNumber = problemNumber;
		_description = description;
	}

	#endregion

	#region Public methods and Properties

	public void Start()
	{
		Console.WriteLine("--------------------------------------------  " + ToString() + "  --------------------------------------------");
		Console.WriteLine(PrintDescription() + "\n");
		Run();
		Console.WriteLine("\nEnd Problem.\n");
		Console.WriteLine("----------------------------------------------------------------------------------------------------");
	}

	public override string ToString() => "Problem" + _problemNumber;

	public string PrintDescription() => _description;

	public int ProblemNumber => _problemNumber;

	#endregion

	#region Abstract method

	protected abstract void Run();

	#endregion
}
