# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added

- Logger
- Blackboard Viewer

### [6.0.0] --- 2023-07-20

## Added

- created ObserverEventArgs

## Changed

- modified the contract for IObserver

### [5.0.1] --- 2023-05-28

## Changed

- added missing inheritance for ScriptableResourceDatabase

### [5.0.0] --- 2023-05-28

## Added

- IInjected
- Injectable
- IInjectionResolver

### Changed

- ScriptableDatabase implementations

## [4.2.0] --- 2023-05-02

### Added

- map key removal

### Changed

- added null check for blackboard deserialization

## [4.1.0] --- 2023-04-27

### Changed

- changed access modifiers on Scriptable database classes and interface

## [4.0.0] --- 2023-04-27

### Added

- Scriptable Object databases (Resource and Reference)

### Changed

- exposed Map keys internally
- added IsPersistent property to IBlackboard
- fixed Blackboard deserialization issue
- obsoleted SettingsPanel

### Removed

- Values constants
- InterpretedValue class 

## [3.2.0] --- 2023-04-16

### Added

- merged com.ikonoclast.globals package into this (minus Constants class)

## [3.1.0] --- 2023-04-15

### Added

- additional content to UnityIcons
- additional helper methods in CustomEditorHelper

### Changed

- added warning when attempting to get CustomEditorHelper.ScreenMousePosition with null event

## [3.0.1] --- 2023-02-22

### Changed

- Map.Copy(...) now overwrites instead of creating a new object

## [3.0.0] --- 2023-02-21

### Added

- generic type 'Get' method for IBlackboard
- null-protection when adding observers to ObservableBlackboard

### Changed

- IBlackboard 'GetUnsafe' method signature

## [2.5.1] --- 2023-02-17

### Changed

- replace sealed with static modifier for Colors class
- test for data equality instead of instance equality in ObservableBlackboard class

## [2.5.0]

### Added

- added 'NONE' static readonly fields for Horizontal and Vertical directions

### Changed

- added ICreatableAsset interface to Entity and Definition scriptable objects

## [2.4.1]

### Removed

- ID field from ISaveObject interface

## [2.4.0] --- 2023-01-31

### Added

- IDispatcher interface for sending Dispatch objects to IReceiver implemeters.
- ICreatableAsset interface 
- ISingleInstanceAsset interface

### Changed

- editor .asmdef platform is now editor-only

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
