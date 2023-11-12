#include <Windows.h>
#include <Leap.h>

#include <SceneGraph/SceneManager.h>

#include <GameContext/GameContext.h>
#include <GameContext/Logger/ImGuiLogger.h>
#include <GameContext/Logger/ConsoleLogger.h>

#include <Debug.h>

// Visual leak detector
#if _DEBUG
#include <vld.h>
#endif

// Default scene
#include "Scenes/Sample.h"

int main()
{
	leap::GameContext::GetInstance().AddLogger<leap::ImGuiLogger>();
	leap::GameContext::GetInstance().AddLogger<leap::ConsoleLogger>();

	leap::Debug::Log("Hello world");
	leap::SceneManager::GetInstance().AddScene("Sample", Example::SampleScene::Load);
	leap::LeapEngine engine{ 1280, 720, "Example" };
	engine.Run(60);
	return 0;
}

int WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int)
{
	return main();
}