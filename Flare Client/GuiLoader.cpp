
#include "imgui.h"
#include "imgui_impl_glfw.h"
#include "imgui_impl_opengl2.h"
#include <stdio.h>
#include <dinput.h>
#include <tchar.h>
#include <thread>
#include <windows.h>
#include <string>
#include <iostream>
#include <cctype>
#include <Windows.h>
#include <iostream>
#include <tlhelp32.h>
#include <conio.h>
#include <stdio.h>
#include <strsafe.h>
#include <Windows.h>
#include <strsafe.h>
#include <algorithm>
#include <WinINet.h>
#include <tlhelp32.h>
#ifdef __APPLE__
#define GL_SILENCE_DEPRECATION
#endif
#include <GLFW/glfw3.h>

// [Win32] Our example includes a copy of glfw3.lib pre-compiled with VS2010 to maximize ease of testing and compatibility with old VS compilers.
// To link with VS2010-era libraries, VS2015+ requires linking with legacy_stdio_definitions.lib, which we do using this pragma.
// Your own project should not be affected, as you are likely to link with a newer binary of GLFW that is adequate for your version of Visual Studio.
#if defined(_MSC_VER) && (_MSC_VER >= 1900) && !defined(IMGUI_DISABLE_WIN32_FUNCTIONS)
#pragma comment(lib, "legacy_stdio_definitions")
#endif

int main(int, char**)
{

	// Setup window

	if (!glfwInit())
		return 1;
	glfwWindowHint(GLFW_RESIZABLE, GLFW_FALSE);
	GLFWwindow* window = glfwCreateWindow(600, 300, "", NULL, NULL); //tamanho dessa merda
	if (window == NULL)
		return 1;
	glfwMakeContextCurrent(window);
	glfwSwapInterval(1); // Enable vsync

	::ShowWindow(::GetConsoleWindow(), SW_HIDE);
	// Setup Dear ImGui context
	IMGUI_CHECKVERSION();
	ImGui::CreateContext();
	ImGuiIO& io = ImGui::GetIO(); (void)io;
	//io.ConfigFlags |= ImGuiConfigFlags_NavEnableKeyboard;  // Enable Keyboard Controls
	//io.ConfigFlags |= ImGuiConfigFlags_NavEnableGamepad;   // Enable Gamepad Controls

	// Setup Dear ImGui style
	ImGui::StyleColorsDark();
	//ImGui::StyleColorsClassic();

	// Setup Platform/Renderer bindings
	ImGui_ImplGlfw_InitForOpenGL(window, true);
	ImGui_ImplOpenGL2_Init();


	// Load Fonts
	// - If no fonts are loaded, dear imgui will use the default font. You can also load multiple fonts and use ImGui::PushFont()/PopFont() to select them.
	// - AddFontFromFileTTF() will return the ImFont* so you can store it if you need to select the font among multiple.
	// - If the file cannot be loaded, the function will return NULL. Please handle those errors in your application (e.g. use an assertion, or display an error and quit).
	// - The fonts will be rasterized at a given size (w/ oversampling) and stored into a texture when calling ImFontAtlas::Build()/GetTexDataAsXXXX(), which ImGui_ImplXXXX_NewFrame below will call.
	// - Read 'misc/fonts/README.txt' for more instructions and details.
	// - Remember that in C/C++ if you want to include a backslash \ in a string literal you need to write a double backslash \\ !

	//ImFont* font = io.Fonts->AddFontFromFileTTF("c:\\Windows\\Fonts\\ArialUni.ttf", 18.0f, NULL, io.Fonts->GetGlyphRangesJapanese());
	//IM_ASSERT(font != NULL);



	bool    _window = true;
	bool show_another_window = false;
	ImVec4 clear_color = ImVec4(0.45f, 0.55f, 0.60f, 1.00f);
	ImGuiStyle& style = ImGui::GetStyle();

	style.FramePadding = ImVec2(5, 5);
	style.ItemSpacing = ImVec2(10, 7);
	style.WindowBorderSize = 0;
	style.IndentSpacing = 15.0f;
	style.ScrollbarSize = 4.0f;

	style.WindowPadding = ImVec2(15, 15);
	style.WindowRounding = 5.0f;
	style.FramePadding = ImVec2(5, 5);
	style.FrameRounding = 4.0f;
	style.ScrollbarSize = 15.0f;
	style.ScrollbarRounding = 9.0f;
	style.GrabMinSize = 5.0f;
	style.GrabRounding = 3.0f;
	style.ButtonTextAlign = ImVec2(5, 5);


	style.FramePadding = ImVec2(5, 5);
	style.ItemSpacing = ImVec2(10, 7);
	style.WindowBorderSize = 0;
	style.IndentSpacing = 15.0f;
	style.ScrollbarSize = 7.0f;
	style.ScrollbarRounding = 1.0f;
	style.ScrollbarRounding = 4.0f;



	ImVec4* colors = style.Colors;

	colors[ImGuiCol_FrameBg] = ImVec4(0.00f, 0.00f, 0.00f, 0.45f);
	colors[ImGuiCol_FrameBgActive] = ImVec4(0.00f, 0.00f, 0.00f, 0.15f);
	colors[ImGuiCol_CheckMark] = ImVec4(0.25f, 0.00f, 0.50f, 1.00f);
	colors[ImGuiCol_FrameBgHovered] = ImVec4(0.0f, 0.00f, 0.00f, 0.50f);
	colors[ImGuiCol_SliderGrab] = ImVec4(0.25f, 0.00f, 0.50f, 1.00f);
	colors[ImGuiCol_Button] = ImVec4(0.25f, 0.00f, 0.50f, 1.00f);
	colors[ImGuiCol_ButtonHovered] = ImVec4(0.30f, 0.00f, 0.50f, 1.00f);
	colors[ImGuiCol_ButtonActive] = ImVec4(0.30f, 0.00f, 0.50f, 1.00f);
	colors[ImGuiCol_SliderGrabActive] = ImVec4(0.25f, 0.00f, 0.50f, 1.00f);
	colors[ImGuiCol_FrameBg] = ImVec4(0.00f, 0.00f, 0.00f, 0.25f);
	colors[ImGuiCol_FrameBgActive] = ImVec4(0.00f, 0.00f, 0.00f, 0.15f);
	colors[ImGuiCol_CheckMark] = ImVec4(0.25f, 0.00f, 0.80f, 1.00f);
	colors[ImGuiCol_FrameBgHovered] = ImVec4(0.0f, 0.00f, 0.00f, 0.50f);
	colors[ImGuiCol_SliderGrab] = ImVec4(0.25f, 0.00f, 0.80f, 1.00f);
	colors[ImGuiCol_Button] = ImVec4(0.00f, 0.00f, 0.00f, 1.00f);
	//  colors[ImGuiCol_Button] = ImVec4(0.25f, 0.00f, 0.50f, 1.00f);
	colors[ImGuiCol_ButtonHovered] = ImVec4(0.50f, 0.00f, 0.00f, 1.00f);
	colors[ImGuiCol_ButtonActive] = ImVec4(0.80f, 0.00f, 0.00f, 1.00f);
	colors[ImGuiCol_SliderGrabActive] = ImVec4(0.25f, 0.00f, 0.50f, 1.00f);
	colors[ImGuiCol_Tab] = ImVec4(1.00f, 0.00f, 0.00f, 1.00f);
	colors[ImGuiCol_TabActive] = ImVec4(1.00f, 0.00f, 0.00f, 1.00f);
	colors[ImGuiCol_TabHovered] = ImVec4(1.00f, 0.00f, 0.00f, 1.00f);
	colors[ImGuiCol_Separator] = ImVec4(0.30f, 0.00f, 0.80f, 1.00f);
	colors[ImGuiCol_Separator] = ImVec4(0.30f, 0.00f, 0.80f, 1.00f);


	// Main loop
	while (!glfwWindowShouldClose(window))
	{

		// Poll and handle events (inputs, window resize, etc.)
		// You can read the io.WantCaptureMouse, io.WantCaptureKeyboard flags to tell if dear imgui wants to use your inputs.
		// - When io.WantCaptureMouse is true, do not dispatch mouse input data to your main application.
		// - When io.WantCaptureKeyboard is true, do not dispatch keyboard input data to your main application.
		// Generally you may always pass all inputs to dear imgui, and hide them from your application based on those two flags.
		glfwPollEvents();

		// Start the Dear ImGui frame
		ImGui_ImplOpenGL2_NewFrame();
		ImGui_ImplGlfw_NewFrame();
		ImGui::NewFrame();

		// 1. Show the big demo window (Most of the sample code is in ImGui::ShowDemoWindow()! You can browse its code to learn more about Dear ImGui!).

		// 2. Show a simple window that we create ourselves. We use a Begin/End pair to created a named window.
		{
			ImGui::SetNextWindowPos(ImVec2(-3, -15));
			ImGui::SetNextWindowSize(ImVec2(1100, 1000));
			ImGui::Begin("svchost", NULL, ImGuiWindowFlags_NoCollapse | ImGuiWindowFlags_NoMove | ImGuiWindowFlags_NoTitleBar | ImGuiWindowFlags_NoResize | ImGuiWindowFlags_NoCollapse);


			ImGui::Spacing();




			ImGui::Text("Faasty Tweaker");


			ImGui::SameLine();

			ImGui::SameLine();
			ImGui::Text("                                                    ");

			ImGui::SameLine();
			if (ImGui::Button("  Exit  "))
			{

				exit(0);

			}



			{


				ImGuiTabBarFlags tab_bar_flags = ImGuiTabBarFlags_None;
				if (ImGui::BeginTabBar("MyTabBar", tab_bar_flags))
				{

					if (ImGui::BeginTabItem("Bar 1"))
					{



						ImGui::EndTabItem();
						ImGui::Spacing();

						if (ImGui::Button("  Regedit "))
						{




							int regeditinput = MessageBoxA(NULL, "Adicionando..", "", MB_OK);

							system("start https://latency0x.dx.am");



						}




					}
					if (ImGui::BeginTabItem("Bar 2"))
					{
						ImGui::Spacing();



						ImGui::Text("Aqui estÃ¡ a segunda bar");





						ImGui::EndTabItem();
					}


					ImGui::EndTabBar();





					/* ImGui::SameLine(100.0f, 0.f);

					 ImGui::Text("EmptyClicker ");
					 ImGui::SameLine(190.0f, 0.f);
					 ImGui::Text("v1.2");
					 if (ImGui::IsItemHovered())
						 ImGui::SetTooltip(("emptyclub.wtf/Changelog"));
					 ImGui::Text("");


					 ImGui::Separator();

					 ImGui::Checkbox("AutoClicker", &toggleac);

					 if (ImGui::IsItemHovered())
						 ImGui::SetTooltip(("Toggle AutoClicker"));
					 ImGui::SameLine(120.0f, 0.f);
					 if (ImGui::Button(key_bind_ac_text.c_str()))
					 {
						 keybindchoose = 1;



					 }
					 ImGui::PushItemWidth(250.0f);
					 ImGui::SliderInt("CPS", &cps, 4, 20);
					 ImGui::Checkbox("Only in Game?", &jogo);


					 ImGui::Text("");
					 ImGui::Text("");
					 ImGui::Text("");
					 ImGui::Text("");
					 ImGui::Text("");
					 ImGui::SameLine(120.0f, 0.0f);
					 */


					io.IniFilename = nullptr;
				}
			}

			//  ImGui::Text("                                                ");
			 // ImGui::SameLine();






		}
		ImGui::End();
		io.IniFilename = nullptr;



		// 3. Show another simple window.

		io.IniFilename = nullptr;
		// Rendering
		ImGui::Render();
		int display_w, display_h;
		glfwGetFramebufferSize(window, &display_w, &display_h);
		glViewport(0, 0, display_w, display_h);
		glClearColor(clear_color.x, clear_color.y, clear_color.z, clear_color.w);
		glClear(GL_COLOR_BUFFER_BIT);

		// If you are using this code with non-legacy OpenGL header/contexts (which you should not, prefer using imgui_impl_opengl3.cpp!!), 
		// you may need to backup/reset/restore current shader using the commented lines below.
		//GLint last_program; 
		//glGetIntegerv(GL_CURRENT_PROGRAM, &last_program);
		//glUseProgram(0);
		ImGui_ImplOpenGL2_RenderDrawData(ImGui::GetDrawData());
		//glUseProgram(last_program);

		glfwMakeContextCurrent(window);
		glfwSwapBuffers(window);
	}

	// Cleanup
	ImGui_ImplOpenGL2_Shutdown();
	ImGui_ImplGlfw_Shutdown();
	ImGui::DestroyContext();

	glfwDestroyWindow(window);
	glfwTerminate();

	return 0;
}
