#include <Leap.h>
#include <SceneGraph/SceneManager.h>
#include <Debug.h>
#include <GameContext/Logger/ImGuiLogger.h>
#include <GameContext/GameContext.h>

#include "Scenes/Sample.h"
int main()
{
	leap::GameContext::GetInstance().AddLogger<leap::ImGuiLogger>();

	leap::Debug::Log("Hello world");
	leap::SceneManager::GetInstance().AddScene("Sample", Voxel::SampleScene::Load);
	leap::LeapEngine engine{ 1280, 720, std::string{"VoxelRenderer"} };
	engine.Run(60);
	return 0;
}