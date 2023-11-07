namespace test_case_flexibase
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Tester.Test1();
			Tester.Test2();
			Tester.Test3();

			InfoLogger.Log("\nВидимо в примере из вакансии (пример номер 3) есть небольшая помарка -\nэлемент с индексом 11 приведён как \"fizz-muzz\", а должен быть \"dog-muzz\".");
		}
	}
}