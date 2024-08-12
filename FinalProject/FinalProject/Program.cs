class Program
{
    public static void Main(String[] args)
    {
        OutputDataToConsole(GetDataFromConsole());
    }
   
    /// <summary>
    /// Returns user's data from console as tuple
    /// </summary>      
    /// <returns></returns>
    private static (string, string, int, bool, int, string[], int, string[]) GetDataFromConsole()
    {
    #region Tuple Definition
        (string Name, string SurName, int Age, bool HasPets,
         int NumOfPets, string[] PetsName, int NumFavColors, string[] FavColors) UserData;
        
        UserData.Name = null; UserData.SurName = null; UserData.Age = 0; UserData.HasPets = false;
        UserData.NumOfPets = 0; UserData.PetsName = null;  UserData.NumFavColors = 0; 
        UserData.FavColors = null;
    #endregion

    #region Name
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine("Введите имя:"); // user's input check is not being performed here
        Console.BackgroundColor = ConsoleColor.Black;
        UserData.Name = Console.ReadLine();
    #endregion

    #region SurName        
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine("Введите фамилию:"); // user's input check is not being performed here
        Console.BackgroundColor = ConsoleColor.Black;
        UserData.SurName = Console.ReadLine();
    #endregion

    #region Age  
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine("Ваш возраст?:");
        Console.BackgroundColor = ConsoleColor.Black;
        string age = Console.ReadLine();
        #endregion

    #region Pets  
        string numOfPets = null;
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine("Имеются ли у вас питомцы (Да/Нет)?:");
        Console.BackgroundColor = ConsoleColor.Black;
        string hasPets = Console.ReadLine();
        if (hasPets == "Да")
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Количество питомцев?:");
            Console.BackgroundColor = ConsoleColor.Black;
            numOfPets = Console.ReadLine();
            UserData.HasPets = true;
        }
    #endregion

    #region Colors  
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine("Количество любимых цветов?:");
        Console.BackgroundColor = ConsoleColor.Black;
        string numFavColors = Console.ReadLine();
    #endregion

    #region Check Input 
        if (CheckUserInput(ref age, ref numOfPets, ref numFavColors))
        {
            UserData.Age = int.Parse(age);
            if (numOfPets != null)
            {
                UserData.PetsName = GetNamesOfPets(int.Parse(numOfPets));
                UserData.NumOfPets = int.Parse(numOfPets);
            }
            UserData.NumFavColors = int.Parse(numFavColors);
            UserData.FavColors = GetFavoriteColors(UserData.NumFavColors);
        }
    #endregion    
    
        return UserData;
    }

    /// <summary>
    /// Checks if user's input is correct: 
    /// all incoming params (age, number of pets, number of colors) values must be as int-type and above zero
    /// </summary>
    /// <param name="age"></param>
    /// <param name="numOfPets"></param>
    /// <param name="numFavColors"></param>
    /// <returns></returns>
    private static bool CheckUserInput(ref string age, ref string numOfPets, ref string numFavColors)
    {
        bool inputCheckResult = false;
        do
        {
        #region Check Age  
            if (!(int.TryParse(age, out int result1) && result1 > 0))
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Введите возраст как целое положительное число:");
                Console.BackgroundColor = ConsoleColor.Black;
                age = Console.ReadLine();
            }
        #endregion

        #region Check Pets 
            else if (!(numOfPets == null) & !(int.TryParse(numOfPets, out int result2) && result2 > 0))
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Введите количество питомцев как целое положительное число:");
                Console.BackgroundColor = ConsoleColor.Black;
                numOfPets = Console.ReadLine();
            }
        #endregion

        #region Check Colors
            else if (!(int.TryParse(numFavColors, out int result3) && result3 > 0))
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Введите количество цветов как целое положительное число:");
                Console.BackgroundColor = ConsoleColor.Black;
                numFavColors = Console.ReadLine();
            }
        #endregion

            else inputCheckResult = true;
        }
        while (!inputCheckResult);
        return inputCheckResult;
    }

    /// <summary>
    /// Return names of pets as array 
    /// </summary>
    /// <param name="numOfPets"></param>
    /// <returns></returns>
    private static string[] GetNamesOfPets(int numOfPets)
    {
        string[] names = new string[numOfPets];
        if (numOfPets != 0)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Сообщите клички питомцев");
            for (int i = 0; i < numOfPets; i++)
            {
                do
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Сообщите кличку {i + 1}-го питомца (введите непустое значение):");
                    Console.BackgroundColor = ConsoleColor.Black;
                    names[i] = Console.ReadLine();
                }
                while (names[i].Length == 0);
            }
        }
        return names;
    }

    /// <summary>
    /// Return favorite colors as array
    /// </summary>
    /// <param name="numFavColors"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    private static string[] GetFavoriteColors(int numFavColors)
    {
        string[] colors = new string[numFavColors];
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine("Сообщите названия цветов");
        for (int i = 0; i < numFavColors; i++)
        {
            do
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Сообщите название {i + 1}-го цвета (введите непустое значение):");
                Console.BackgroundColor = ConsoleColor.Black;
                colors[i] = Console.ReadLine();
            }
            while (colors[i].Length == 0);
        }
        return colors;
    }

    /// <summary>
    /// Outputs user's data to console
    /// </summary>
    /// <param name="userData"></param>
    private static void OutputDataToConsole((string, string, int, bool, int, string[], int, string[]) userData)
    {
        Console.BackgroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Вы сообщили следующую информацию:");
        Console.WriteLine("Ваше имя: " + userData.Item1);
        Console.WriteLine("Ваша фамилия: " + userData.Item2);
        Console.WriteLine("Ваш возраст: " + userData.Item3);
        if (userData.Item4)
        {
            Console.WriteLine("Количество питомцев: " + userData.Item5);
            foreach (string item in userData.Item6)
            {
                Console.WriteLine("Имя питомца: " + item);
            }
        }
        else
        {
            Console.WriteLine("Нет питомцев");
        }
        Console.WriteLine("Количество любимых цветов: " + userData.Item7);
        foreach (string item in userData.Item8)
        {
            Console.WriteLine("Название цвета: " + item);
        }
    }

}
