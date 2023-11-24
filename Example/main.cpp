#include "stdafx.h"
#include <Windows.h>

#include <GameContext/Logger/ImGuiLogger.h>
#include <GameContext/Logger/ConsoleLogger.h>

// Visual leak detector
#if _DEBUG
#include <vld.h>
#endif

// Default scene
#include "Scenes/Sample.h"

int main()
{
	// Setup loggers
	leap::GameContext::GetInstance().AddLogger<leap::ImGuiLogger>();
	leap::GameContext::GetInstance().AddLogger<leap::ConsoleLogger>();

	// Create engine
	leap::LeapEngine engine{ 1280, 720, "Example" };
	
	// Set settings after initializing
	auto afterInitializing = []()
		{
			leap::Debug::Log("Hello world");
			leap::ServiceLocator::GetPhysics().SetEnabledDebugDrawing(true);
			leap::SceneManager::GetInstance().AddScene("Sample", Example::SampleScene::Load);
		};

	// Initialize & run engine
	engine.Run(afterInitializing, 60);
	
	return 0;
}

int WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int)
{
	return main();
}