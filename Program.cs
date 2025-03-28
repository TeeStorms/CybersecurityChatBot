using System;
using System.Media;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using System.Text;
using System.Data.SqlTypes;

namespace ChatBot1._2
{
    class Program
    {
        static void Main()
        {
            // Clear console and set colors for better readability
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            // Display an instruction for the user to maximize the window
            Console.WriteLine("\n====================================================");
            Console.WriteLine("|    For the best experience, please maximize your  |");
            Console.WriteLine("|    window before continuing the application.      |");
            Console.WriteLine("====================================================");
            Console.ResetColor();

            // Prompt user to press a key before proceeding
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nPress any key to continue...");
            Console.ResetColor();
            Console.ReadKey(true); // Waits for user input

            // Display welcome message
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n==================================================");
            Console.WriteLine("|          WELCOME TO YOUR CYBERSECURITY ASSISTANT! |");
            Console.WriteLine("==================================================");
            Console.ResetColor();

            // Display ASCII art related to cybersecurity
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
           Fight Bugs                      |     |
                                \\_V_//
                                \/=|=\/
                                 [=v=]
                               __\___/_____
                              /..[  _____  ]
                             /_  [ [  M /] ]
                            /../.[ [ M /@] ]
                           <-->[_[ [M /@/] ]
                          /../ [.[ [ /@/ ] ]
     _________________]\ /__/  [_[ [/@/ C] ]
    <_________________>>0---]  [=\ \@/ C / /   
       ___      ___   ]/000o   /__\ \ C / /    
          \    /              /....\ \_/ /     
       ....\||/....           [___/=\___/     
      .    .  .    .          [...] [...]    
     .      ..      .         [___/ \___]     
     .    0 .. 0    .         <---> <--->    
  /\/\.    .  .    ./\/\      [..]   [..]    
 / / / .../|  |\... \ \ \    _[__]   [__]_   
/ / /       \/       \ \ \  [____>   <____]                                                     
            ");
            Console.ResetColor();

            // Path to the audio file
            string audioFilePath = Path.Combine("audio.wav");


            // Check if the welcome audio file exists
            if (File.Exists(audioFilePath))
            {
                try
                {
                    // Play audio if the file is found
                    SoundPlayer player = new SoundPlayer(audioFilePath);
                    player.Play();

                    // Type out welcome message with delay for a better user experience
                    string welcomeMessage = "Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online.";
                    foreach (char c in welcomeMessage)
                    {
                        Console.Write(c);
                        Thread.Sleep(79); // Simulate a typing effect
                    }
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error playing audio: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("\nOops! Audio file not found.");
            }

            // Display a motivational message for cybersecurity awareness
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n====================================================");
            Console.WriteLine("|      Ready to protect your digital world,       |");
            Console.WriteLine("|      let's dive into cybersecurity tips!        |");
            Console.WriteLine("====================================================");
            Console.ResetColor();

            // Ask user for their name
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please enter your name:");
            string name = Convert.ToString(Console.ReadLine());
            Console.ResetColor();
            Console.WriteLine("\n==================================================");

            // Start the chatbot conversation
            StartTextChat(name);

            // Play a beep sound when the chatbot session ends
            Console.Beep();
        }

        static void StartTextChat(string name)
        {
            while (true)
            {
                // Display chatbot options for user interaction
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n====================================");
                Console.WriteLine(" Options: ");
                Console.WriteLine("====================================");
                Console.ResetColor();

                // Set console encoding to UTF-8 to support symbols and emojis
                Console.OutputEncoding = Encoding.UTF8;

                // Inform user of available chatbot functionalities
                Console.WriteLine($"\n🔹 Hey {name}, let's explore cybersecurity together! 🔹");
                Console.WriteLine("💡 Here’s what you can do:");
                Console.WriteLine("📌 Type 'topics' to discover cybersecurity topics.");
                Console.WriteLine("❓ Ask me: 'How are you?', 'What is your purpose?', or 'What can I ask you about?'.");
                Console.WriteLine("🚪 Type 'exit' anytime to leave the chat.");

                // Prompt user for input
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("You: ");
                Console.ResetColor();

                try
                {
                    string userInput = Console.ReadLine().Trim();

                    // If user input is empty, prompt them to enter a valid response
                    if (string.IsNullOrEmpty(userInput))
                    {
                        Respond("I didn't quite understand that. Could you please rephrase?");
                        continue;
                    }

                    userInput = userInput.ToLower();

                    // Exit condition for chatbot session
                    if (userInput == "exit")
                    {
                        Respond($"Hey {name}, stay vigilant and protect your online presence! Have a great day!");
                        break;
                    }
                    // Show available topics
                    else if (userInput == "topics")
                    {
                        ShowTopics();
                    }
                    else
                    {
                        // Generate and display response based on user input
                        string response = GenerateResponse(userInput);
                        Respond(response);
                    }
                }
                catch (Exception ex)
                {
                    Respond($"Oops! Something went wrong. Please try again. (Error: {ex.Message})");
                }
            }
        }

        static string GenerateResponse(string userInput)
        {
            try
            {
                userInput = userInput.ToLower(); // Ensure case-insensitivity

                // Response for phishing-related queries
                if (userInput.Contains("phishing") || userInput.Contains("email"))
                {
                    return "🚨 **Phishing Scams Warning!**\n" +
                           "- ⚠️ Beware of emails that create **urgency**.\n" +
                           "- 🔗 **Never** click on suspicious links.\n" +
                           "- 📧 Always verify the sender's email address.";
                }
                // Response for password-related queries
                else if (userInput.Contains("password"))
                {
                    return "🔑 **Strong Password Practices:**\n" +
                           "- Use at least **12 characters**.\n" +
                           "- Mix **uppercase, lowercase, numbers, and symbols**.\n" +
                           "- Avoid common words and predictable patterns.";
                }
                // Response for suspicious links
                else if (userInput.Contains("link") || userInput.Contains("suspicious"))
                {
                    return "🔗 **Avoid Suspicious Links:**\n" +
                           "- 🚫 Never click on unverified links.\n" +
                           "- 🛡️ Hover over links to preview the destination before clicking.\n" +
                           "- 🔍 Use a **URL checker** to verify safety.";
                }
                // Response for safe browsing
                else if (userInput.Contains("safe browsing") || userInput.Contains("online safety"))
                {
                    return "🌍 **Safe Browsing Tips:**\n" +
                           "- 🔒 Use **HTTPS** websites for secure connections.\n" +
                           "- 🛑 Avoid downloading files from **unknown sources**.\n" +
                           "- 🕵️‍♂️ Use a **trusted ad-blocker** to prevent malicious ads.";
                }
                // Response for chatbot's well-being query
                else if (userInput.Contains("how are you"))
                {
                    return "😊 I'm just a chatbot, but I'm here and ready to assist you!";
                }
                // Response for chatbot's purpose query
                else if (userInput.Contains("purpose"))
                {
                    return "🤖 **My Purpose:**\n" +
                           "- 🛡️ Provide cybersecurity **tips and best practices**.\n" +
                           "- 🔍 Help you recognize **online threats**.\n" +
                           "- 🚀 Keep you safe in the digital world!";
                }else if (userInput.Contains("ask about"))
                {
                    return "🔑 **Strong Password Practices:**\n" +
                           "        - 🚨 **Phishing Scams Warning!**\n" +
                           "        - 🔗 **Suspicious Links:**\n" +
                           "        - 🌍 **Safe Browsing Tips:**";
                }
                else
                {
                    return "I didn't quite understand that. Could you please rephrase?";
                }
            }
            catch (Exception ex)
            {
                return $"⚠️ Oops! I encountered an issue. (Error: {ex.Message})";
            }
        }


        static void ShowTopics()
        {
            Respond("\n📚 **I can help with the following topics:**\n" +
                    "- 🎣 **Phishing emails** (How to avoid scams)\n" +
                    "- 🔑 **Strong password practices** (Stay secure online)\n" +
                    "- 🚨 **Recognizing suspicious links** (Don't get hacked!)\n" +
                    "- 🌍 **Safe browsing tips** (Browse the web securely)");
        }


        static void Respond(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nChatbot: {message}\n");
            Console.ResetColor();
        }
    }
}
