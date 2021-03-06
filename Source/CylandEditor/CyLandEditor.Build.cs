// Copyright 1998-2019 Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;

public class CyLandEditor : ModuleRules
{
	public CyLandEditor(ReadOnlyTargetRules Target) : base(Target)
	{
        PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

        PrivateDependencyModuleNames.AddRange(
			new string[] {
				"Core",
				"CoreUObject",
				"ApplicationCore",
				"Slate",
				"SlateCore",
                "EditorStyle",
				"Engine",
				"CyLand",
				"RenderCore",
                "RHI",
                "InputCore",
				"UnrealEd",
				"PropertyEditor",
				"ImageWrapper",
                "EditorWidgets",
                "Foliage",
				"ViewportInteraction",
				"VREditor",
				"Landscape",
			}
			);


		PrivateIncludePathModuleNames.AddRange(
			new string[] {
                "MainFrame",
				"DesktopPlatform",
				"ContentBrowser",
                "AssetTools",
				"LevelEditor"
			}
			);
        PrivateIncludePaths.AddRange(
            new string[] {
                "CyLandEditor/Private",
            }

        );

        DynamicallyLoadedModuleNames.AddRange(
			new string[] {
				"MainFrame",
				"DesktopPlatform",
			}
			);

		if (Target.Platform == UnrealTargetPlatform.Win64 || Target.Platform == UnrealTargetPlatform.Win32)
		{
			// VS2015 updated some of the CRT definitions but not all of the Windows SDK has been updated to match.
			// Microsoft provides this shim library to enable building with VS2015 until they fix everything up.
			//@todo: remove when no longer neeeded (no other code changes should be necessary).
			if (Target.WindowsPlatform.bNeedsLegacyStdioDefinitionsLib)
			{
				PublicAdditionalLibraries.Add("legacy_stdio_definitions.lib");
			}
		}

		// KissFFT is used by the smooth tool.
		if (Target.bBuildDeveloperTools &&
			(Target.Platform == UnrealTargetPlatform.Win64 || Target.Platform == UnrealTargetPlatform.Win32 || Target.Platform == UnrealTargetPlatform.Mac || Target.Platform == UnrealTargetPlatform.Linux))
		{
			AddEngineThirdPartyPrivateStaticDependencies(Target, "Kiss_FFT");
		}
		else
		{
			PublicDefinitions.Add("WITH_KISSFFT=0");
		}
	}
}
