using System.Windows;

namespace ECommerce.Extensions;

public class MessageBoxExtention
{
    public static void ShowError(string message)
    {
        MessageBox.Show(
            message,
            "Error!",
            MessageBoxButton.OK,
            MessageBoxImage.Error);
    }

    public static MessageBoxResult ShowConfirmation(string message)
    {
        var result = MessageBox.Show(
            message,
            "Confirm your action!",
            MessageBoxButton.YesNo,
            MessageBoxImage.Warning);

        return result;
    }

    public static void ShowSuccess(string message)
    {
        MessageBox.Show(
            message,
            "Success",
            MessageBoxButton.OK,
            MessageBoxImage.Information);
    }
}
