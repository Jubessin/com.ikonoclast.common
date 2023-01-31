# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added

- IDispatcher interface for sending Dispatch objects to IReceiver implemeters.
- ICreatableAsset, ISingleInstanceAsset interfaces
- AssetCreator EditorWindow

## [2.3.0] --- 2023-01-30

### Changed

- added IEditorSaveObject interface to SettingsPanel
- exposed static fields on HorizontalDirection and VerticalDirection, and made readonly

## [2.2.0] --- 2023-01-29

### Added

- Blackboard objects (Blackboard, ObservableBlackboard, ReadOnlyBlackboard)

### Changed

- added generic type to IIdentity interface

## [2.1.0] --- 2023-01-29

### Added

- added additional serialization construct for ISaveObject.
- added HasKey(string) method to Map class

## [2.0.0]

### Added

- added editor functionality (panels, icons, shortcuts, interfaces)
- added value constants
- added InterpretedValue class

## [1.0.0]

### Added

- constants, interfaces, objects, and types
