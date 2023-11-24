#pragma once

// C++ includes
#include <memory>
#include <vector>

// GLM includes
#include <vec2.hpp>
#include <vec4.hpp>
#include <vec3.hpp>
#include <ivec.h>

// Core engine
#include <Leap.h>
#include <GameContext/GameContext.h>
#include <GameContext/Timer.h>
#include <ServiceLocator/ServiceLocator.h>
#include <Components/Component.h>

// Utils includes
#include <Quaternion.h>
#include <Vector2.h>
#include <Vector3.h>
#include <Matrix.h>
#include <Debug.h>
#include <LambdaCommand.h>
#include <DataCommand.h>
#include <EventPool.h>
#include <Command.h>
#include <Observer.h>
#include <Subject.h>
#include <ReflectionUtils.h>
#include <Singleton.h>

// Scene
#include <SceneGraph/Scene.h>
#include <SceneGraph/SceneManager.h>
#include <SceneGraph/GameObject.h>

// Base components
#include <Components/Transform/Transform.h>

#include <Components/RenderComponents/MeshRenderer.h>
#include <Components/RenderComponents/DirectionalLightComponent.h>
#include <Components/RenderComponents/UIComponents/CanvasComponent.h>
#include <Components/RenderComponents/UIComponents/RectTransform.h>
#include <Components/RenderComponents/UIComponents/Button.h>
#include <Components/RenderComponents/UIComponents/CanvasActions.h>
#include <Components/RenderComponents/TerrainComponent.h>
#include <Components/RenderComponents/CameraComponent.h>

#include <Components/Audio/AudioSource.h>
#include <Components/Audio/AudioListener.h>

#include <Components/Physics/BoxCollider.h>
#include <Components/Physics/Rigidbody.h>
#include <Components/Physics/SphereCollider.h>
#include <Components/Physics/CapsuleCollider.h>

// Interface includes
#include <Interfaces/IRenderer.h>
#include <Interfaces/IMaterial.h>
#include <Interfaces/IMeshRenderer.h>
#include <Interfaces/ITexture.h>
		 
#include <Interfaces/IShape.h>
#include <Interfaces/IPhysics.h>
#include <Interfaces/IPhysicsMaterial.h>
#include <Interfaces/IPhysicsObject.h>
#include <Interfaces/IPhysicsScene.h>
		 
#include <Interfaces/IAudioClip.h>
#include <Interfaces/IAudioSystem.h>

// Data includes
#include <Data/Vertex.h>
#include <Data/CollisionData.h>
#include <Data/CustomMesh.h>
#include <Data/Force.h>
#include <Data/ForceMode.h>
#include <Data/RaycastHit.h>
#include <Data/RenderData.h>
#include <Data/Rigidbody.h>
#include <Data/SimulationEventData.h>
#include <Data/Sprite.h>
#include <Data/SpriteVertex.h>

// Input includes
#include <InputManager.h>
#include <Keyboard.h>