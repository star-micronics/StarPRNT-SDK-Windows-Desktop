using System;
using System.Collections.Generic;
using System.Windows;

namespace StarPRNTSDK
{
    public static class Util
    {
        public static void GoNextPage(Uri uri)
        {
            if (uri == null)
            {
                return;
            }

            MainWindow mainWindow = GetMainWindow();

            mainWindow.NavigateNextPage(uri);
        }

        public static void GoBackPage()
        {
            MainWindow mainWindow = GetMainWindow();

            if (mainWindow.CanGoBack)
            {
                mainWindow.GoBack();
            }
        }

        public static void GoBackMainPage()
        {
            MainWindow mainWindow = GetMainWindow();

            MainPage mainPage = new MainPage();

            mainWindow.Navigate(mainPage);
        }

        public static void JumpPage(Uri uri)
        {
            if (uri == null)
            {
                return;
            }

            MainWindow mainWindow = GetMainWindow();

            MainPage mainPage = new MainPage();
            mainPage.JumpUri = uri;

            mainWindow.Navigate(mainPage);
        }

        public static MainWindow GetMainWindow()
        {
            return (MainWindow)Application.Current.MainWindow;
        }

        public static void FocusMainWindow()
        {
            MainWindow mainWindow = GetMainWindow();

            mainWindow.WindowState = WindowState.Normal;
            mainWindow.Focus();
        }

        public static bool IsContainsNullOrEmptyArray<T>(List<T[]> arrayList)
        {
            foreach (T[] array in arrayList)
            {
                if (IsNullOrEmpty(array))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsEqualAllArraysLength<T>(List<T[]> arrayList)
        {
            for (int i = 0; i < arrayList.Count - 1; i++)
            {
                T[] array1 = arrayList[i];
                T[] array2 = arrayList[i + 1];

                if (!IsEqualLength(array1, array2))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsNullOrEmpty<T>(T[] array)
        {
            return array == null || array.Length == 0;
        }

        public static bool IsEqualLength<T>(T[] array1, T[] array2)
        {
            if (array1 == null || array2 == null)
            {
                return false;
            }

            return array1.Length == array2.Length;
        }

        public static bool IsRange(int value, int from, int to)
        {
            return (from <= value && value <= to);
        }
    }
}
