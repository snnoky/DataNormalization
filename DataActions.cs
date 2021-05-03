using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Newtonsoft.Json;

namespace Zadanie1MIW
{
    public class DataActions
    {
        public static int decisionClassColumnIndex = 0;
        public static bool SwapValues = false;

        public static void Menu(UserConfig userData, DataTable data)
        {
            var decision = "";
            Console.WriteLine("Czy wyświetlić wybrane dane? t/T - Tak | inne - Nie");
            decision = Console.ReadLine();
            if (decision == "t" || decision == "T")
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    Console.WriteLine(string.Join(" ", data.Rows[i].ItemArray));
                }
            }
            Console.WriteLine("\nJak zapisać dane?");
            Console.WriteLine("1 - Csv");
            Console.WriteLine("2 - Xlsx");
            Console.WriteLine("3 - Json");
            Console.WriteLine("inne - Nie zapisać");
            decision = Console.ReadLine();
            if (decision == "1")
            {
                DataActions.SaveDataTableAsCSV(data, userData.DataPath + "_" + userData.DataSaveName + ".csv");
                Console.WriteLine("\nZapisano.");

            }
            else if (decision == "2")
            {
                DataActions.SaveDataTableAsXLSX(data, userData.DataPath + "_" + userData.DataSaveName + ".xlsx");
                Console.WriteLine("\nZapisano.");
            }
            else if (decision == "3")
            {
                DataActions.SaveDataTableAsJson(data, userData.DataPath + "_" + userData.DataSaveName + ".json");
                Console.WriteLine("\nZapisano.");
            }
            else
            {
                Console.WriteLine("Nie zapisano!");
            }

            if (userData.DataName != "australian" && userData.DataName != "breast-cancer-wisconsin")
            {
                Console.WriteLine("Zamienić wartości symboliczne na liczbowe? t/T-tak inne-nie");
                decision = Console.ReadLine();
                if (decision == "t" || decision == "T")
                {
                    DataActions.SwapValues = true;
                    //Console.WriteLine("Change symbols to numbers");
                    data = DataActions.ChangeSymbolToNumeric(data, userData);

                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        Console.WriteLine(string.Join(" ", data.Rows[i].ItemArray));
                    }
                    //Console.WriteLine("Ask to normalize the Set.");
                    //Console.WriteLine("Show normalized Set.");
                    Console.WriteLine("Czy znormalizować dane? t/T - Tak | inne - Nie");
                    decision = Console.ReadLine();


                    if (decision == "t" || decision == "T")
                    {
                        var normalizedData = DataActions.NormalizeData(data,
                            double.Parse(userData.DataNormalizationFrom.ToString()),
                            double.Parse(userData.DataNormalizationTo.ToString()));

                        Console.WriteLine("\nZnormalizowane dane:\n");
                        for (int i = 0; i < normalizedData.Rows.Count; i++)
                        {
                            Console.WriteLine(string.Join(" ", normalizedData.Rows[i].ItemArray.Select(x => string.Format("{0:0.##}", x))));
                        }

                        Console.WriteLine("\nJak zapisać dane?");
                        Console.WriteLine("1 - Csv");
                        Console.WriteLine("2 - Xlsx");
                        Console.WriteLine("3 - Json");
                        Console.WriteLine("inne - Nie zapisać");
                        decision = Console.ReadLine();
                        if (decision == "1")
                        {
                            DataActions.SaveDataTableAsCSV(normalizedData, "../../../_S" + DateTime.Now.ToString("MM-dd-yyyy") + "normalized" + userData.DataSaveName + ".csv");
                            Console.WriteLine("\nZapisano.");

                        }
                        else if (decision == "2")
                        {
                            DataActions.SaveDataTableAsXLSX(normalizedData, "../../../_S" + DateTime.Now.ToString("MM-dd-yyyy") + "normalized" + userData.DataSaveName + ".xlsx");
                            Console.WriteLine("\nZapisano.");
                        }
                        else if (decision == "3")
                        {
                            DataActions.SaveDataTableAsJson(normalizedData, "../../../_S" + DateTime.Now.ToString("MM-dd-yyyy") + "normalized" + userData.DataSaveName + ".json");
                            Console.WriteLine("\nZapisano.");
                        }
                        else
                        {
                            Console.WriteLine("Nie zapisano!");
                        }
                    }

                    //Console.WriteLine("end.");
                }
                else
                {
                    Console.WriteLine("Czy znormalizować dane? t/T - Tak | inne - Nie");
                    decision = Console.ReadLine();


                    if (decision == "t" || decision == "T")
                    {
                        var normalizedData = DataActions.NormalizeData(data,
                            double.Parse(userData.DataNormalizationFrom.ToString()),
                            double.Parse(userData.DataNormalizationTo.ToString()));

                        Console.WriteLine("\nZnormalizowane dane:\n");
                        for (int i = 0; i < normalizedData.Rows.Count; i++)
                        {
                            Console.WriteLine(string.Join(" ", normalizedData.Rows[i].ItemArray.Select(x => string.Format("{0:0.##}", x))));
                        }

                        Console.WriteLine("\nJak zapisać dane?");
                        Console.WriteLine("1 - Csv");
                        Console.WriteLine("2 - Xlsx");
                        Console.WriteLine("3 - Json");
                        Console.WriteLine("inne - Nie zapisać");
                        decision = Console.ReadLine();
                        if (decision == "1")
                        {
                            DataActions.SaveDataTableAsCSV(normalizedData, "../../../_" + DateTime.Now.ToString("MM-dd-yyyy") + "normalized" + userData.DataSaveName + ".csv");
                            Console.WriteLine("\nZapisano.");

                        }
                        else if (decision == "2")
                        {
                            DataActions.SaveDataTableAsXLSX(normalizedData, "../../../_" + DateTime.Now.ToString("MM-dd-yyyy") + "normalized" + userData.DataSaveName + ".xlsx");
                            Console.WriteLine("\nZapisano.");
                        }
                        else if (decision == "3")
                        {
                            DataActions.SaveDataTableAsJson(normalizedData, "../../../_" + DateTime.Now.ToString("MM-dd-yyyy") + "normalized" + userData.DataSaveName + ".json");
                            Console.WriteLine("\nZapisano.");
                        }
                        else
                        {
                            Console.WriteLine("Nie zapisano!");
                        }
                    }
                }
            }
            else
            {
                //Console.WriteLine("Ask to normalize the Set.");
                //Console.WriteLine("Show normalized Set.");
                //Console.WriteLine("Ask to save the normalized Set.");
                Console.WriteLine("Czy znormalizować dane? t/T - Tak | inne - Nie");
                decision = Console.ReadLine();

                if (decision == "t" || decision == "T")
                {
                    var normalizedData = DataActions.NormalizeData(data,
                        double.Parse(userData.DataNormalizationFrom.ToString()),
                        double.Parse(userData.DataNormalizationTo.ToString()));

                    Console.WriteLine("\nZnormalizowane dane:\n");
                    for (int i = 0; i < normalizedData.Rows.Count; i++)
                    {
                        Console.WriteLine(string.Join(" ", normalizedData.Rows[i].ItemArray.Select(x => string.Format("{0:0.##}", x))));
                    }

                    Console.WriteLine("\nJak zapisać dane?");
                    Console.WriteLine("1 - Csv");
                    Console.WriteLine("2 - Xlsx");
                    Console.WriteLine("3 - Json");
                    Console.WriteLine("inne - Nie zapisać");
                    decision = Console.ReadLine();
                    if (decision == "1")
                    {
                        DataActions.SaveDataTableAsCSV(normalizedData, "../../../_" + DateTime.Now.ToString("MM-dd-yyyy") + "normalized" + userData.DataSaveName + ".csv");
                        Console.WriteLine("\nZapisano.");

                    }
                    else if (decision == "2")
                    {
                        DataActions.SaveDataTableAsXLSX(normalizedData, "../../../_" + DateTime.Now.ToString("MM-dd-yyyy") + "normalized" + userData.DataSaveName + ".xlsx");
                        Console.WriteLine("\nZapisano.");
                    }
                    else if (decision == "3")
                    {
                        DataActions.SaveDataTableAsJson(normalizedData, "../../../_" + DateTime.Now.ToString("MM-dd-yyyy") + "normalized" + userData.DataSaveName + ".json");
                        Console.WriteLine("\nZapisano.");
                    }
                    else
                    {
                        Console.WriteLine("Nie zapisano!");
                    }
                }
                //Console.WriteLine("end.");
            }
        }

        public static DataTable GetValuesFromFile(string filePath, string fileTypePath, string separator)
        {

            var table = new DataTable();
            if (!File.Exists(filePath) || !File.Exists(fileTypePath))
            {
                Console.WriteLine("Podano złą ścieżkę!");
            }
            else
            {
                var lines = File.ReadAllLines(filePath);
                var linesOfTypes = File.ReadAllLines(fileTypePath);

                var counter = 0; // liczenie kolumn
                var lineCounter = 0; // liczenie linii do bloku try/catch

                foreach (var line in linesOfTypes)
                {

                    var type = line.Split(" ")[1];
                    if (type == "d")
                    {
                        decisionClassColumnIndex = counter;
                        table.Columns.Add(($"kolumna{++counter}(Class attr)").ToString(), typeof(string));
                    }
                    else
                    {
                        table.Columns.Add(($"kolumna{++counter}").ToString(), type == "s" ? typeof(string) : typeof(double));
                    }
                    //table.Columns.Add(($"kolumna{++counter}").ToString(), type == "s" ? typeof(string) : typeof(double));
                }

                //table.Columns.Add(($"kolumna{++counter}").ToString(), typeof(string)); 

                foreach (var line in lines)
                {
                    lineCounter++;
                    var values = line.Split(separator);
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = values[i].Replace(".", ",");
                    }

                    var row = table.NewRow();

                    if (values.Contains("?"))
                    {
                        Console.WriteLine("Pominięto wiersz " + lineCounter + " natrafiono na \"?\"");
                        continue;
                    }

                    row.ItemArray = values;

                    //try
                    //{
                    //    row.ItemArray = values;
                    //}
                    //catch (ArgumentException e)
                    //{
                    //    //Console.WriteLine("Pominięto wiersz "+e.Message);
                    //    Console.WriteLine("Pominięto wiersz " + lineCounter + " natrafiono na \"?\"");
                    //    continue;
                    //}

                    table.Rows.Add(row);
                }
            }
            return table;
        }

        public static DataTable ChangeSymbolToNumeric(DataTable table, UserConfig config)
        {
            var newTable = table;

            for (int i = 0; i < newTable.Columns.Count; i++)
            {
                if (newTable.Columns[i].DataType != typeof(string)) continue;
                if (i == decisionClassColumnIndex) continue;

                var items = newTable.Select().Select(x => x[i]);
                var itemsCast = items.Cast<string>().ToList();

                for (int j = 0; j < itemsCast.Count; j++)
                {
                    var item = (string)newTable.Rows[j][i];

                    if (item == "?")
                    {
                        continue;
                    }

                    try
                    {
                        newTable.Rows[j][i] = config.DataSymbolicsToNumerics.First(x => x.From == item).To;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Brak informacji w UserConfig na temat zamiany elementu: {newTable.Rows[j][i]}");
                        throw;
                    }

                }
            }

            return newTable;
        }
        public static DataTable NormalizeData(DataTable table, double fromNumber, double toNumber)
        {
            var normalizedTable = table;

            for (int j = 0; j < normalizedTable.Columns.Count; j++)
            {
                if (j == decisionClassColumnIndex) continue;
                if (!SwapValues && normalizedTable.Columns[j].DataType != typeof(double)) continue;

                var items = normalizedTable.Select().Select(x => Convert.ToDouble(x[j]));
                var itemsCast = items.Cast<double>().ToList();
                var min = itemsCast.Min();
                var max = itemsCast.Max();

                for (int i = 0; i < itemsCast.Count; i++)
                {
                    normalizedTable.Rows[i][j] = ((itemsCast[i] - min) / (max - min)) * ((toNumber - fromNumber)) + fromNumber;
                }
            }

            return normalizedTable;
        }

        public static void SaveDataTableAsCSV(DataTable data, string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            StringBuilder builder = new StringBuilder();

            IEnumerable<string> columnNames = data.Columns.Cast<DataColumn>().Select(column => column.ColumnName);

            builder.AppendLine(string.Join(CultureInfo.CurrentCulture.TextInfo.ListSeparator, columnNames));  //CultureInfo rozwiązanie na ustawienia regionalne.

            foreach (DataRow row in data.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                builder.AppendLine(string.Join(CultureInfo.CurrentCulture.TextInfo.ListSeparator, fields));
            }

            File.WriteAllText(filePath, builder.ToString());
        }

        public static void SaveDataTableAsXLSX(DataTable data, string filePath)
        {
            var workbook = new XLWorkbook();

            workbook.Worksheets.Add(data, filePath.Split("/").Last());
            workbook.SaveAs(filePath);
        }

        public static void SaveDataTableAsJson(DataTable data, string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            var jsonResult = JsonConvert.SerializeObject(data);
            File.WriteAllText(filePath, jsonResult);
        }
    }
}

