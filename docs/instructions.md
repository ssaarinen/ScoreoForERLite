# User instructions for ScoreOForEResultsLite

ScoreOForEResultsLite is a simple application for calculating Score-O / Rogaining style results from orienteering
results collected with [EResults Lite](https://www.oriento.fi/eresults/lite?lng=en).

## Installation

The application is available in the Microsoft Store: [Web link](https://apps.microsoft.com/detail/9n50r1gndn4t).
EResults Lite is also required and can be downloaded from [Oriento](https://www.oriento.fi/eresults/lite?lng=en) web site.

After installation, start the application from the Start menu or by searching for "ScoreOForEResultsLite".

## Usage

To use the application during an orienteering event, follow these steps:

1. Create a new competition in EResults Lite and save it to a file (for example `competition.json`).
2. Open the same competition file in ScoreOForEResultsLite by choosing *File* -> *Open* or by dragging the file
   into the application window.
3. When results are read into EResults Lite, they are automatically available in ScoreOForEResultsLite; the most
   recent result is highlighted in the results list. Double-click any result to open its detailed view.
4. Optionally enable *View* -> *Auto show latest result* to automatically open the detailed view when a new
   result is received.

### Running start and mass start

Running/flying start window or mass start are calculated the same way as in EResults Lite. By default, the zero
punch time is used to calculate the competitor's time. If a start time is added for a competitor, it is used
in the results calculation instead of the zero punch time. In a mass start, the same start time must be
set for all competitors in EResults Lite.

## Series

EResults Lite does not support separate series, so they are not available in ScoreOForEResultsLite either.

## Settings

Open the settings dialog from *File* -> *Settings*. Settings can be changed at any time and all results will be
recalculated using the new settings. Settings are saved automatically when the application closes and are loaded
automatically when the application starts.

Following settings are available:

### General
- **Finish control code**: The control code that indicates the finish control in the competition. Punches recorded
  after the finish control are ignored in the results calculation. Default: `100`.
- **Start control code**: The control code that indicates the start control. Default: `0` (not currently editable from
  the settings dialog).
- **Reader control code**: The control code that indicates the reader control. Default: `250` (not currently editable
  from the settings dialog).

### Scoring
- **Max time (format: hh:mm:ss)**: The maximum allowed time for the competition. Competitors finishing after this time
  incur penalty points.
- **Penalty interval (seconds)**: The time interval used when calculating penalties; for each penalty interval exceeded
  after the max time the penalty score is applied.
- **Penalty per interval**: The penalty points added for each penalty interval exceeded after the max time. Example: if
  max time is `1:00:00`, penalty interval is `60` s and penalty per interval is `1` point, a competitor finishing in
  `1:02:01` receives `3` penalty points (3 intervals x 1 point).
- **Allowed controls**: A comma-separated list of control codes and, optionally, their point values. Controls not listed
  are ignored in scoring. You can specify points for a control manually using the format `code[:points]`. Example:
  `31,32:5,33:10,80,91` means control `32` => 5 points, control `33` => 10 points; points for controls `31`, `80` and `91`
  are calculated using the scoring function.
- **Scoring function**: Used to calculate points for allowed controls that do not have manually assigned points. Options
  provided by the application include:
  - **Code = points**: The control code value is the points awarded (for example, control `31` => 31 points).
  - **First number = points**: The leading part of the control code is used as the points awarded. Examples: control
    `31` => 3 points; control `125` => 12 points.
  - **First number = points (max 10)**: Same as above, but capped at 10 points. Examples: control `31` => 3 points;
    control `125` => 10 points.

### Saving settings to an EResults Lite competition file

You can save settings into the EResults Lite competition file from the settings dialog:

1. Open *File* -> *Settings*.
2. Adjust the settings as needed.
3. Select *Actions* -> *Copy to clipboard*.
4. In EResults Lite, edit the competition and add a new course with any name (for example, "ScoreO"). Paste the
   clipboard contents into the course controls section. The pasted text will look similar to the example below.

```
@SV=1;eyJNVFMiOiIzNjAwIiwiUElTIjoiNjAiLCJQUEUEkiOiIxIiwiU0YiOiIxc3QgbnVtYmVyID0gcG9pbnRzIiwiQUMiOiIzMSwzMiwzMywzNCwzNSwzNiwzNyw0MSw0Miw0Myw0NCw0NSw1MSw1Miw1Myw1NCw1NSw2MSw3Nyw5MCw5MSIsIkZDIjoiOTIifQ==
```

### Loading saved settings from an EResults Lite competition

If you previously saved settings to an EResults Lite competition file as described above, load them back into
ScoreOForEResultsLite by opening *File* -> *Settings* and selecting *Actions* -> *Load from competition file*. This
action is enabled only when the opened competition file contains saved settings.

## Exporting the results

To export results to HTML for web publication:

1. In the main window choose *File* -> *Export* -> *HTML...*.
2. Select the result and split files to export and provide an event title (or accept the defaults).
3. Click *Export* to generate the HTML files. Note that existing files with the same names will be overwritten.

## No score or No name in results

Only competitors marked "OK" in EResults Lite are scored. In addition, a competitor must have at least the start,
finish and reader punches to be scored. If a competitor is marked as "No name in results" in EResults Lite they
will still appear in exported results but without a name.
