#include "../stdafx.h"
#include "Sample.h"

void Example::SampleScene::Load(leap::Scene& scene)
{
	const auto pCamera{ scene.CreateGameObject("Main camera") };
	pCamera->AddComponent<leap::CameraComponent>()->SetAsActiveCamera(true);
	pCamera->GetTransform()->SetWorldPosition(0, 0, -5);

	const auto pDirLight{ scene.CreateGameObject("Directional light") };
	pDirLight->AddComponent<leap::DirectionalLightComponent>()->GetTransform()->SetWorldRotation(0, 45, 45, true);
}