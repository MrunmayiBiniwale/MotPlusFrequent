namespace MotPlusFrequent
{
    public class Program
    {
        static void Main(string[] args)
        {
            string userInput, motInterdit;

            //Get user input and validate
            while (true)
            {
                Console.WriteLine("Veuillez entrer des phrases. ");
                userInput = Console.ReadLine();
                if (!(0 < userInput.Length && userInput.Length < 1000))
                {
                    Console.WriteLine("Le limit de phrase est 0-1000 characters. Veuillez re-entrer le phrase dans le limit :");
                }
                else
                {
                    break;
                }
            }
            
            //get the banned word
            Console.WriteLine("Veuillez entrer le mot interdit dans les phrases. ");
            motInterdit = Console.ReadLine();
            
            string[] wordsUserInput = userInput.Split(' ');
            int[] countOccurences = new int[wordsUserInput.Length];
            int counter = 0;
            int outputIndex = 0;
            Program program = new Program();

            //remove special characters, spaces. // Convert the string to lower case
            for (int i = 0; i < wordsUserInput.Length; i++) 
            {
                wordsUserInput[i] = program.removeSpecialCharacters(wordsUserInput[i]);
                wordsUserInput[i] = wordsUserInput[i].Trim().ToLower();
            }

            string[] distinctUserInput = wordsUserInput.Distinct().ToArray();

            //Count the number of occurences of each word
            for (int i = 0; i < distinctUserInput.Length; i++)
            {
                for (int j = 0; j < wordsUserInput.Length; j++)
                {
                    if (distinctUserInput[i] == wordsUserInput[j])
                        counter++;
                }
                countOccurences[i] = counter;
                counter = 0;
            }

            //set the number of times banned word occurred to -1 
            for (int i = 0; i < distinctUserInput.Length; i++)
            {
                if (distinctUserInput[i].ToLower() == motInterdit.ToLower())
                    countOccurences[i] = -1;                    
            }

            //Get the index of the word occured for the maximum times
            outputIndex = countOccurences.ToList().IndexOf(countOccurences.Max());

            Console.WriteLine("Output : " + distinctUserInput[outputIndex]);

        }

        //function to remove special characters
        public string removeSpecialCharacters(string wordsUserInput)
        {
            wordsUserInput = wordsUserInput.Replace(',', ' ');
            wordsUserInput = wordsUserInput.Replace(';', ' ');
            wordsUserInput = wordsUserInput.Replace('.', ' ');
            wordsUserInput = wordsUserInput.Replace(':', ' ');

            return wordsUserInput;
        }
    }
}
