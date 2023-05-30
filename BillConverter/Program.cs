// See https://aka.ms/new-console-template for more information

using System.Drawing;
using System.Numerics;
using System.Text.Json;
using BillConverter;
using Microsoft.VisualBasic.FileIO;


var billInfo = JsonSerializer.Deserialize<List<BillInfo>>(FetchBillInfo.BillResponse);

var item = billInfo.First();


var descriptions = item.description.Split("\n");


var line = 1;

for (var i = 0; i < descriptions.Length - 1; i++)
{
    switch (i)
    {
        case 15 or 16 or 17 or 21 or 22 or 25 or 26 or 29 or 30 or 32 or 36 or 37 or 38 or 39 or 40 or 41 or 45 or 48:
            continue;
        case 4:
            Console.WriteLine($"{line} {descriptions[i]} {descriptions[i + 1]}\n");
            i++;
            break;
        case 11:
            Console.WriteLine($"{line} {descriptions[i]} {descriptions[15]} {descriptions[16]}\n");
            break;
        case 14:
            Console.WriteLine($"{line} {descriptions[i]} {descriptions[17]}\n");
            break;
        case 20:
            Console.WriteLine($"{line} {descriptions[i]} {descriptions[21]}  {descriptions[22]}\n");
            break;

        case 24:
            Console.WriteLine($"{line} {descriptions[i]} {descriptions[25]}  {descriptions[26]}\n");
            break;
        case 27:
            Console.WriteLine($"{line} {descriptions[i]} {descriptions[29]}\n");
            break;
        case 28:
            Console.WriteLine($"{line} {descriptions[i]} {descriptions[30]} \n");
            break;
        case 31:
            Console.WriteLine($"{line} {descriptions[i]} {descriptions[32]} \n");
            break;
        case 33:
            Console.WriteLine($"{line} {descriptions[i]} {descriptions[36]} {descriptions[39]}\n");
            break;
        case 34:
            Console.WriteLine($"{line} {descriptions[i]} {descriptions[37]} {descriptions[40]}\n");
            break;
        case 35:
            Console.WriteLine($"{line} {descriptions[i]} {descriptions[38]} {descriptions[41]}\n");
            break;
        case 44:
            Console.WriteLine($"{line} {descriptions[i]} {descriptions[45]}\n");
            break;
        case 47:
            Console.WriteLine($"{line} {descriptions[i]} {descriptions[48]} \n");
            break;
        default:
            Console.WriteLine($"{line} {descriptions[i]}\n");
            break;
    }

    line++;
}

/*

5 - 6


*/