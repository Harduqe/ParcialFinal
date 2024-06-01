using System;

public class Program
{
    // VARIABLES GLOBALES
    static int n; // Filas del tablero
    static int m; // Columnas del tablero
    static int[,] board; // Tablero
    static int posX = 0, posY = 0;
    static bool escKeyPressed = false;

    public static void Main(string[] args)
    {
        GetBoardSize();
        InitializeBoard();
        ShowBoard();
        PrintMenu();
    }

    private static void GetBoardSize()
    {
        Console.WriteLine("Ingrese el tamaño del tablero (n x m):");

        Console.Write("Filas (n): ");
        n = int.Parse(Console.ReadLine());

        Console.Write("Columnas (m): ");
        m = int.Parse(Console.ReadLine());

        board = new int[n, m];
    }

    private static void PrintMenu()
    {
        while (!escKeyPressed)
        {
            ConsoleKeyInfo keyPressed;

            Console.WriteLine("Use las teclas de dirección o WASD para mover el '0', o presione 'ESC' para salir");
            Console.WriteLine("Pulse Flecha Derecha o 'D' para mover a la derecha");
            Console.WriteLine("Pulse Flecha Izquierda o 'A' para mover a la izquierda");
            Console.WriteLine("Pulse Flecha Arriba o 'W' para mover hacia arriba");
            Console.WriteLine("Pulse Flecha Abajo o 'S' para mover hacia abajo");
            Console.WriteLine("Pulse 'Esc' para salir");

            keyPressed = Console.ReadKey(true); // ReadKey(true) para evitar mostrar la tecla presionada

            switch (keyPressed.Key)
            {
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    MoveO("derecha");
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    MoveO("izquierda");
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    MoveO("arriba");
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    MoveO("abajo");
                    break;
                case ConsoleKey.Escape:
                    escKeyPressed = true;
                    break;
            }

            ShowBoard();
        }
    }

    private static void MoveO(string direction)
    {
        int newX = posX, newY = posY;

        switch (direction)
        {
            case "derecha":
                if (posY < m - 1) newY++;
                break;
            case "izquierda":
                if (posY > 0) newY--;
                break;
            case "arriba":
                if (posX > 0) newX--;
                break;
            case "abajo":
                if (posX < n - 1) newX++;
                break;
        }

        if (newX != posX || newY != posY)
        {
            board[newX, newY] += board[posX, posY]; // Sumar el valor de la posición anterior a la nueva
            board[posX, posY] = 0; // Establecer la posición anterior a cero
            posX = newX;
            posY = newY;
        }
    }

    private static void ShowBoard()
    {
        Console.Clear();
        Console.WriteLine("Mueva el '0' para sumar puntos!\n");
        for (int f = 0; f < n; f++)
        {
            for (int c = 0; c < m; c++)
            {
                if (f == posX && c == posY)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(board[f, c] + " "); // Mostrar el valor en la posición actual del jugador
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(board[f, c] + " ");
                }
            }
            Console.WriteLine();
        }
    }

    private static void InitializeBoard()
    {
        Random random = new Random();

        for (int f = 0; f < n; f++)
        {
            for (int c = 0; c < m; c++)
            {
                board[f, c] = random.Next(1, 10); // Genera un número aleatorio entre 1 y 9
            }
        }

        board[posX, posY] = 0; // Posición inicial
    }
}