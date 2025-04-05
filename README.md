# Steganography App

This is a .NET MAUI application for generating and retrieving passwords using steganography techniques. The app provides a user-friendly interface for creating passwords bu using images, as well as retrieving passwords from images.

## Features

- **Create Password**: Generate a password and embed it into an image.
- **Get Password**: Retrieve a password from an image using a PIN.
- **Password Generator Settings**: Configure the size of the generated passwords.

## Pages

### MainPage

The main page provides two options:
- **Create Password**: Navigate to the `OptionAPage` to generate a password and embed it into an image.
- **Get Password**: Navigate to the `OptionBPage` to retrieve a password from an image using a PIN.

### OptionAPage

This page allows users to:
- Upload an image by tapping on the image preview.
- Generate a password by clicking the "Create Password" button.
- Copy the generated password to the clipboard.

### OptionBPage

This page allows users to:
- Upload an image by tapping on the image preview.
- Enter a PIN to retrieve the password embedded in the image.
- Copy the retrieved password to the clipboard.

### UserConfigPopUp

This page allows users to configure the password generator settings:
- Enter the desired size of the password.
- Submit the configuration.

## Navigation

The app uses a Shell navigation structure with the following routes:
- **MainPage**: The home page of the app.

## How to Run

1. Ensure you have .NET 9 installed.
2. Open the solution in Visual Studio 2022.
3. Set the startup project to `SteganographyApp`.
4. Run the project.

## Dependencies

- .NET MAUI
- Visual Studio 2022

## License

This project is licensed under the MIT License.
