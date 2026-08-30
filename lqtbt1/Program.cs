using lmq_Day01.Services;
using lmq_Day01.Views;

namespace lmq_Day01;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        StudentService studentService = new StudentService();
        StudentConsoleView view = new StudentConsoleView();
        MenuManager menu = new MenuManager(studentService, view);

        menu.NapDuLieuMau();
        menu.ChayMenu();
    }
}
