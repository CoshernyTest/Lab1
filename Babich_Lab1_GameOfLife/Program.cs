using System;
using System.IO;

string path_in = "input.txt";
string path_out = "output.txt";

bool[,] initial_field;  // Вместо char клетка является bool. True = живая, False = мертвая
int generations = -1;
int[] size = new int[2];

#region ЧТЕНИЕ/ПОЛУЧЕНИЕ ИНФОРМАЦИИ
using (StreamReader sr = new StreamReader(path_in, System.Text.Encoding.Default))
{
    generations = Convert.ToInt32(sr.ReadLine());
    size = Array.ConvertAll(sr.ReadLine().Split(' '), s => int.Parse(s));

    initial_field = new bool[size[0], size[1]];

    // Чтение матрицы
    for (int y = 0; y < size[1]; y++)
    {
        string line = sr.ReadLine();

        for (int x = 0; x < size[0]; x++)
        {
            initial_field[x, y] = (line[x] == 'x');
        }
    }
}
#endregion

#region ОБРАБОТКА ИНФОРМАЦИИ

bool[,] new_field = LiveSteps(initial_field, generations);
string result = ConwaysMatrixToText(new_field);

#endregion 

#region ЗАПИСЬ/ВЫВОД
using (StreamWriter sw = new StreamWriter(path_out, false, System.Text.Encoding.Default))
{
    sw.Write("\r\n\r\n");
    sw.Write(result);
}
#endregion


#region МЕТОДЫ
int CountAliveNeighbors(bool[,] field, int cell_x, int cell_y)
{
    int count = 0;

    // rel_x, rel_y - координаты соседней клетки относительно центральной, проверяемой клетки
    for (int rel_y = -1; rel_y <= 1; rel_y++)
    {
        for (int rel_x = -1; rel_x <= 1; rel_x++)
        {
            if (rel_y == 0 && rel_x == 0) { continue; } // При отн. координатах (0,0) проверяется центральная клетка - нет смысла
            else if (GetCellStatus(field, cell_x + rel_x, cell_y + rel_y)) {  count++; }
        }
    }

    return count;
}

//
// Рассчитывает новое состояние клетки
//
bool GetNewCellStatus(bool[,] field, int cell_x, int cell_y)
{
    bool new_status = false;
    bool cur_status = GetCellStatus(field, cell_x, cell_y);
    int neighbours = CountAliveNeighbors(field, cell_x, cell_y);

    if (cur_status) // Если клетка жива
    {
        if (neighbours > 3 || neighbours < 2)
        {
            new_status = false; // Умирает
        }
        else { new_status = true; }
    }
    else   // Если клетка мертва
    {
        if (neighbours == 3)
        { new_status = true; } // Оживает
    }

    return new_status;
}

//
// Узнает текущее состояние клетки
//
bool GetCellStatus(bool[,] field, int cell_x, int cell_y)
{
    cell_x %= field.GetLength(0);   // Если справа от крайней правой клетки
    cell_y %= field.GetLength(1);   // Если снизу от крайней нижней клетки

    if (cell_x == -1) { cell_x = field.GetLength(0) - 1; } // Если слева от крайней левой клетки
    if (cell_y == -1) { cell_y = field.GetLength(1) - 1; } // Если сверху от крайней верхней клетки


    return field[cell_x, cell_y];
}

bool[,] LiveSteps(bool[,] initial_field, int steps) 
{
    bool[,] new_field = (bool[,])initial_field.Clone();

    //Console.WriteLine("STARTING STATE");
    //Console.WriteLine(ConwaysMatrixToText(initial_field));

    for (int i = 0; i < steps; i++) 
    {
        //Console.WriteLine("GENERATION " + i.ToString());
        new_field = LiveOneStep(new_field);
        //Console.WriteLine(ConwaysMatrixToText(new_field));
    }

    return new_field;
}

bool[,] LiveOneStep(bool[,] field) 
{
    int size_x = field.GetLength(0);
    int size_y = field.GetLength(1);
    bool[,] new_field = (bool[,])field.Clone();

    for (int y = 0; y < size_y; y++)
    {
        for (int x = 0; x < size_x; x++)
        {
            new_field[x, y] = GetNewCellStatus(field, x, y);
        }
    }

    return new_field; 
}

string ConwaysMatrixToText(bool[,] field)
{
    var text = "";

    for (int y = 0; y < field.GetLength(1); y++)
    {
        for (int x = 0; x < field.GetLength(0); x++)
        {
            if (field[x, y]) { text += 'x'; }
            else { text += '.'; }
        }
        text += "\r\n";
    }

    return text;
}
#endregion