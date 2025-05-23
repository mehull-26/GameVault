# GameVault - Universal Save System for Unity

GameVault is a **simple, scalable, and flexible save system** for Unity. It supports **Registry and Local (File-Based) save systems for now**, with built-in **encryption, slot-based saves, and dictionary/list serialization**.

## 🌟 Features

- **Multiple Save Systems**: Registry and Local File (Cloud planned).
- **Encryption Support**: AES-based encryption for local saves.
- **Slot-Based Saving**: Manage multiple save slots efficiently.
- **Dictionary & List Serialization**: Handles nested structures within save data.
- **Singleton-Based Architecture**: Ensures a single access point for game-wide data.
- **Customizable Save Paths**: Users can set custom save directories.

**⭕ NOTE: doesn't support serialization of dictionaries nested within dictionaries**

## 🛠️ Installation

1. **Download & Import**: Download the release unity package and add the package to your Unity project.
2. **Attach GameVault**: Add the `GameVault` script to an empty GameObject once and the GameVault factory object will exist for the entire lifetime of game.
3. **Initialize & Use**:
   ```csharp
   GameVault.factory.RegSaveSystem.Save("playerName", "John Doe");
   string playerName = GameVault.factory.RegSaveSystem.Load<string>("playerName");
   ```

## 🏗️ Future Improvements

- **Cloud Save Integration**.
- **Auto-Save Helper Module**.
- **Support for Binary Serialization (Performance Boost)**.

GameVault - Making game saves seamless & flexible! 🚀

[📖 Documentation](DOCUMENTATION.md)
