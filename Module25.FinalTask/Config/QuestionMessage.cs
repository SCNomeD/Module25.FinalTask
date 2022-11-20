namespace Module25.FinalTask.Config
{
    public static class QuestionMessage
    {
        public static string Question(string Message)
        {
            Console.Write(Message + " ");
            string answer = Console.ReadLine() ?? "";

            return answer;
        }
    }
}
