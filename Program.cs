using CommandCenter.Utility;

Console.WriteLine("Command Center v0.0.1");
string? input;
List<string> options = new List<string>()
{
    "Access the user's web browser",
    "Access the user's file system",
    "Access the user's calendar"
};
while (true)
{
    Console.Write("How can I help you? (type 'exit' to quit): ");
    input = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(input))
    {
        switch (input.ToLower())
        {
            case "exit":
                Console.WriteLine("Goodbye!");
                Environment.Exit(0);
                break;
            default:
                try
                {
                    string systemPrompt = @$"Choose the best option to complete the user's task.

{string.Join("\n", options)}

#OUTPUT#
Only output the index of the option you choose starting at index 0.
";
                    string assistantPrompt = "You are in control of a computer and must accomplish the user's tasks";
                    string response = LLM.Prompt(systemPrompt, assistantPrompt, input);
                    int option = int.Parse(response);
                    string optionText = options[option];
                    Console.WriteLine($"The AI chose option {option}: {optionText}");
                    switch (option)
                    {
                        case 0: // Access the user's web browser
                            break;
                        case 1: // Access the user's file system
                            break;
                        case 2: // Access the user's calendar
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                break;
        }
    }
}
