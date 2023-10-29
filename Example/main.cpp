#include <Leap.h>
#include <SceneGraph/SceneManager.h>
#include <Debug.h>
#include <GameContext/Logger/ImGuiLogger.h>
#include <GameContext/GameContext.h>
#include <GameContext/Logger/ConsoleLogger.h>

#include "Scenes/Sample.h"
int main()
{
	leap::GameContext::GetInstance().AddLogger<leap::ImGuiLogger>();
	leap::GameContext::GetInstance().AddLogger<leap::ConsoleLogger>();

	leap::Debug::Log("Hello world");
	leap::SceneManager::GetInstance().AddScene("Sample", Example::SampleScene::Load);
	leap::LeapEngine engine{ 1280, 720, std::string{"Example"} };
	engine.Run(60);
	return 0;
}