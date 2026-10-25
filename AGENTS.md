# Repository guidance

- Build with `dotnet build src/EmulatorTestSuites.slnx`. Run native Microsoft Testing Platform tests from `src`, where `global.json` selects the runner: `dotnet test --solution EmulatorTestSuites.slnx`.
- Keep all five package projects and four test projects in the solution. The Single Step generator is a development tool, built but not run by normal CI.
- Use NUnit with `MrKWatkins.Assertions` (`value.Should().Equal(...)` and related fluent assertions). Follow the existing test naming and structure.
- Format source changes with `dotnet format src/EmulatorTestSuites.slnx`.
- Preserve embedded test data and its third-party licences and notices. Do not regenerate or download upstream suites for a build migration. The generator's output directories are found relative to `EmulatorTestSuites.slnx`.
- Build and Release call `MrKWatkins/build/dotnet/project`; Release publishes prevalidated packages through NuGet trusted publishing and documentation through GitHub Pages.
- Handwritten Markdown lives in `docs/content`, retaining the CPU subfolders. `docs/site.json` defines guide navigation and all five API inputs. Project spelling terms live in `docs/vocabulary`.
- Preview with `python3 docs/preview.py` or the JetBrains **Preview documentation** configuration, then open `http://localhost:5173/EmulatorTestSuites/`. Docker and the .NET 10 SDK are required.
- Generated API pages, package output and rendered sites belong in ignored `artifacts`; never commit them. Keep project automation in Python.
