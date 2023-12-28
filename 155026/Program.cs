using System;

namespace _155026
{
    internal class Program
    {
        //  function retuens the number of the char in the random string
        public static int numOfRepeat(string randStr, char repeatedChar)
        {
            int number_of_repeat = 0;  //  counter that counts the repeat
            for (int i = 0; i < randStr.Length; i++)  //  for loop to read all the random chars in the random string
            {
                if (repeatedChar == randStr[i])  //  if statement to check if st[i] equals to the random char in the question
                {
                    number_of_repeat++;  //  rising the counter by +1
                }
            }
            return number_of_repeat;
        }
        //  Control Panal that displays the result of the user 
        public static void Control_Panal(int[] Ua, int[] Ca, string[] type, string[] Qu)
        {
            Console.WriteLine("User answers\t\t   Correct asnwers\t\t   Type\t\t  Question");
            Console.WriteLine("*************************************************************************************");
            for (int i = 0; i <= Qu.Length - 1; i++)
                Console.WriteLine(Ua[i] + "\t\t\t\t" + Ca[i] + "\t\t\t" + type[i] + "\t\t" + Qu[i]);
        }
        static void Main(string[] args)
        {
            string[] QuestionsArry;  //  declare the question array
            int[] Right_ans_array;  //  declare the correct answer arrat
            int[] User_ans_array;   //  declare the user answer array
            string[] answerType_Array;  //  the type of the answer array(right , wrong)


            Console.WriteLine("Windows Version: {0}", Environment.OSVersion);
            Console.WriteLine("64 Bit operating system? :", Environment.Is64BitOperatingSystem ? "Yes" : "No");
            Console.WriteLine("PC Name : {0}", Environment.MachineName);
            Console.WriteLine("Number of CPUS : {0}", Environment.ProcessorCount);
            Console.WriteLine("Windows folder : {0}", Environment.SystemDirectory);
            Console.WriteLine("Logical Drives Available : {0}", String.Join(", ",
            Environment.GetLogicalDrives()).TrimEnd(',', ' ').Replace("\\", String.Empty));
            Console.WriteLine();
            Random rand = new Random();

            string alphabet = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";  //  declare a string contains all the small and capital letters and the numbers
            Console.WriteLine("Please Enter the number of Questions: ");
            int QuestionsNum = int.Parse(Console.ReadLine());  //  reading the number of the question from the user
            if (QuestionsNum == 0)  // check if the user choose 0 
            {
                //  do/while loop to repeat the question if the number of questions was 0
                do
                {
                    Console.WriteLine("The question number should be an integer  > 0, Please enter it again:");
                    QuestionsNum = int.Parse(Console.ReadLine());
                } while (QuestionsNum == 0);

            }
            //  make the length as the length of the questions number
            QuestionsArry = new string[QuestionsNum];
            Right_ans_array = new int[QuestionsNum];
            User_ans_array = new int[QuestionsNum];
            answerType_Array = new string[QuestionsNum];
            int number_of_questions = 0;
            char question_char = ' ';

            int correct_ans_num = 0;  //  count the correct answers number
            int wrong_ans_num = 0;    //  count the wrong answers number
            int diff;                 //  difficulty level
            string user_name;         //  user name



            Console.WriteLine("Please enter your name (first and last name) and you SVU ID number with a space between each part\n(Accepted Chars :A-Z a-z 0-9 The entered text should contain at least 2 of accepted chars");
            user_name = Console.ReadLine();  //  reading the user name from the user

            Console.WriteLine("Your full name and id ---:" + user_name);


            //  method to delete all the distictchars from the user name 
            string distinctChars = "";
            for (int i = 0; i < user_name.Length; i++)  //  for loop to read the full user name (first name, last name and ID)
            {
                char nonReChars = user_name[i];
                if ((nonReChars >= 'A' && nonReChars <= 'Z') || (nonReChars >= 'a' && nonReChars <= 'z') || (nonReChars >= '0' && nonReChars <= '9'))
                {
                    bool Isfound = false;
                    for (int k = 0; k < distinctChars.Length; k++)
                    {
                        if (distinctChars[k] == nonReChars)
                        {
                            Isfound = true;
                            break;
                        }
                    }
                    if (!Isfound)
                    {
                        distinctChars += nonReChars;
                    }
                }
            }
            user_name = distinctChars;
            Console.WriteLine("Distinct chars are: " + user_name);  //  return the user name but only the distinct chars

            int user_ans;
            string rand_str;

            while (number_of_questions < QuestionsNum)  //  while loop to keep the question in the range of question number which was taken from the user
            {
                Console.WriteLine();
                Console.WriteLine("Question " + ++number_of_questions);
                Console.WriteLine("**********************************");
                //  do / while loop to force the user to choose a number between 3 nad 100
                do
                {

                    Console.WriteLine("Please enter an integer value between 9 and 100\n(the number of characters from which to enumerate the most or least repeated characters  == Degree of difficulty");
                    diff = int.Parse(Console.ReadLine());
                } while (diff < 9|| diff > 100);

                rand_str = "";

                for (int j = 0; j < diff; j++)    //  for loop to create a random string based on diff level
                {
                    int rand_arry_created = rand.Next(0, alphabet.Length - 1);
                    rand_str += alphabet[rand_arry_created];
                    question_char = rand_str[rand.Next(rand_str.Length)];

                }
                Console.WriteLine("what is the number of time the character " + question_char + " repeated in the following text:\nto ignore the question type ignoe:");
                Console.WriteLine(rand_str);
                user_ans = int.Parse(Console.ReadLine()); //  reading the answer from the user

                QuestionsArry[number_of_questions - 1] = rand_str; //  store the question in the question array
                User_ans_array[number_of_questions - 1] = user_ans;    //  store the user answer in the user answer array
                Right_ans_array[number_of_questions - 1] = numOfRepeat(rand_str, question_char);   //  store the right answer in the right answer array by calling the numOfRepeat function

                if (User_ans_array[number_of_questions - 1] == Right_ans_array[number_of_questions - 1])    //  check if the user's answer was right
                {
                    correct_ans_num++;  //  rising right answer counter by +1
                    answerType_Array[number_of_questions - 1] = "Correct";  // storin the value Correct in the type array
                }
                else if (User_ans_array[number_of_questions - 1] != Right_ans_array[number_of_questions - 1])
                {
                    wrong_ans_num++;  //  rising Wrong answer counter by +1
                    answerType_Array[number_of_questions - 1] = "Wrong";  // storin the value Wrong in the type array
                }


            }
            //  display the results 
            string DisplayPanel = "";
            while (DisplayPanel != "exit")
            {
                Console.WriteLine("To get the number of Correct answers, type 1");
                Console.WriteLine("To get the number of Wrong answers, type 2");
                Console.WriteLine("To View all the questions with correct and answered response ,type 3");
                Console.WriteLine("To exit, type exit");
                DisplayPanel = Console.ReadLine();
                Console.WriteLine();
                switch (DisplayPanel)
                {
                    case "1": Console.WriteLine("The number of Corerect answers is : " + correct_ans_num); break;
                    case "2": Console.WriteLine("The number of Wrong answers is : " + wrong_ans_num); break;
                    case "3": Control_Panal(User_ans_array, Right_ans_array, answerType_Array, QuestionsArry); break;
                    case "exit": DisplayPanel = "exit"; break;
                }
            }
        }


    }

}
