namespace Module25.FinalTask.Checks
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
