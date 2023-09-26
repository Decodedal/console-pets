// the ourAnimals array will store the following: 
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 6];

// TODO: Convert the if-elseif-else construct to a switch statement

// create some initial ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            break;

        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            break;

        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            break;

        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;

        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
}

// display the top-level menu options

Console.Clear();

Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
Console.WriteLine(" 1. List all of our current pet information");
Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
Console.WriteLine(" 5. Edit an animal’s age");
Console.WriteLine(" 6. Edit an animal’s personality description");
Console.WriteLine(" 7. Display all cats with a specified characteristic");
Console.WriteLine(" 8. Display all dogs with a specified characteristic");
Console.WriteLine();


readResult = Console.ReadLine();

do
{
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");
    readResult = Console.ReadLine();

    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    Console.WriteLine($"You selected menu option {menuSelection}.");

    switch (menuSelection)
    {
        case "1":
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] == "ID #: ")
                    continue;

                {
                    Console.WriteLine("");
                    for (int j = 0; j < 6; j++)
                        Console.WriteLine(ourAnimals[i, j]);
                }
            }
            break;
        case "2":
            bool done = false;
            int currentCount = 0;
            for (int i = 0; i < maxPets; i++)
                if (ourAnimals[i, 0] != "ID #: ")
                    currentCount++;

            if (currentCount < maxPets)
            {
                Console.WriteLine($"We currently have {currentCount} pets that need homes. We can manage {maxPets - currentCount} more.");
            }
            while(!done && currentCount < maxPets){
                currentCount++;
                
                bool validEntery = false;

                do
                {
                    Console.WriteLine("Is this a Cat or a Dog?");
                    readResult = Console.ReadLine();
                    
                    if(readResult != null)
                        animalSpecies = readResult.ToLower();
                    
                    if(animalSpecies == "cat" || animalSpecies == "dog")
                        validEntery = true;
                    else
                        validEntery = false;

                }while(!validEntery);

                //creates the id first letter of species and number 
                animalID = animalSpecies[0] + currentCount.ToString();
                animalSpecies = "Species: " + animalSpecies;
                validEntery = false;
                do
                {
                    Console.WriteLine($"How old is this {animalSpecies}");
                    readResult = Console.ReadLine();

                    if(readResult != null && int.TryParse(readResult, out int test))
                    {
                        if(test >=0 && test <=33)
                        {
                            animalAge = "Age: " + readResult;
                            validEntery = true;
                        }
                        else
                            Console.WriteLine("That is not a valid age");
                    }
                }while(!validEntery);

                do
                {
                    Console.WriteLine("Please enter a Physical discription of the animal");

                    readResult = Console.ReadLine();
                    if(readResult != null)
                        animalPhysicalDescription = readResult;

                    if(readResult == "")
                        animalPhysicalDescription = "tbd";
                    

                }while(animalPhysicalDescription == "");
                
                do
                {
                    Console.WriteLine("Please enter a Personality discription of the animal");

                    readResult = Console.ReadLine();
                    if(readResult != null)
                        animalPersonalityDescription = readResult;

                    if(readResult == "")
                        animalPersonalityDescription = "tdb";
                    

                }while(animalPersonalityDescription == "");
                
                do
                {
                    Console.WriteLine("Please enter a nickname for the animal");

                    readResult = Console.ReadLine();
                    if(readResult != null)
                        animalNickname = readResult;
                    
                    if(readResult =="")
                        animalNickname = "tbd";

                }while(animalNickname == "");

                ourAnimals[currentCount, 0] = "ID #: " + animalID;
                ourAnimals[currentCount, 1] = animalSpecies;
                ourAnimals[currentCount, 2] = animalAge;
                ourAnimals[currentCount, 3] = "nickname: " + animalNickname;
                ourAnimals[currentCount, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[currentCount, 5] = "Personality: " + animalPersonalityDescription;

                if(currentCount < maxPets)
                {
                    do
                    {
                        Console.WriteLine("Do you want to create a new pet, Y or N");
                        readResult = Console.ReadLine();
                        if(readResult != null)
                        {
                            menuSelection = readResult.ToLower();
                            if(menuSelection == "n")
                                done = true;
                        }
                    }while(menuSelection != "y" && menuSelection != "n");
                }
            }
            if(currentCount >= maxPets)
            {
            Console.WriteLine("We have reached capacity can not store any other pets");    
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            }
            break;

        case "3":
            Console.WriteLine("Ensure animal ages and physical descriptions are complete");
            break;

        case "4":
            Console.WriteLine(" Ensure animal nicknames and personality descriptions are complete");
            break;

        case "5":
            Console.WriteLine("Edit an animal’s age");
            break;

        case "6":
            Console.WriteLine(" 6. Edit an animal’s personality description");
            break;

        case "7":
            Console.WriteLine("Display all cats with a specified characteristic");
            break;

        case "8":
            Console.WriteLine("Display all dogs with a specified characteristic");
            break;

        default:
            Console.WriteLine("Invalid selection please try again");
            break;
    }

    Console.WriteLine("Press the Enter key to continue");
} while (menuSelection != "exit");

// pause code execution
readResult = Console.ReadLine();


