# QuickXorHash

This is an implementation of Microsoft's QuickXORHash algorithm, which is used as a hash in OneDrive. You can learn more about it in the [official documentation](https://learn.microsoft.com/en-us/onedrive/developer/code-snippets/quickxorhash?view=odsp-graph-online).

## Usage

### Command-Line Utility

You can use the command-line utility to calculate and display the hash of a file. Here are some examples:

```shell
# Calculate the hash of a file
QuickXorHash.exe --file <file_path>

# Compare the calculated hash to an expected hash
QuickXorHash.exe --file <file_path> --expected-hash <expected_hash>
```

### WinForms Application
The WinForms application allows you to calculate hashes and visually compare them using a graphical interface. It supports file selection from the file system (including drag-and-drop) and comparison with a reference value.