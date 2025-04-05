
using System;
using System.IO;
using System.Linq;
using Microsoft.Maui.Controls;

namespace SteganographyApp;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}

	// Drop image in the box
    private async void OnImageDropped(object sender, DropEventArgs e)
    {




		// handle error
		if (e.Data != null)
		{
		}

		// once an image is dropped. 




    }
}