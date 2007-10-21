/*
* Copyright (c) 2007 SlimDX Group
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in
* all copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
* THE SOFTWARE.
*/
#pragma once

using namespace System::Drawing;

namespace SlimDX
{
	namespace Direct3D9
	{
		[Flags]
		public enum class SpriteFlags : Int32
		{
			None = 0,
			DoNotSaveState = D3DXSPRITE_DONOTSAVESTATE,
			DoNotModifyRenderState = D3DXSPRITE_DONOTMODIFY_RENDERSTATE,
			ObjectSpace = D3DXSPRITE_OBJECTSPACE,
			Billboard = D3DXSPRITE_BILLBOARD,
			AlphaBlend = D3DXSPRITE_ALPHABLEND,
			Texture = D3DXSPRITE_SORT_TEXTURE,
			SortDepthFrontToBack = D3DXSPRITE_SORT_DEPTH_FRONTTOBACK,
			SortDepthBackToFront = D3DXSPRITE_SORT_DEPTH_BACKTOFRONT,
		};

		ref class Texture;

		public ref class Sprite : public DirectXObject<ID3DXSprite>
		{
		public:
			Sprite( ID3DXSprite* sprite );
			Sprite( Device^ device );
			~Sprite() { Destruct(); }
			DXOBJECT_FUNCTIONS;

			void Begin( SpriteFlags flags );
			void End();
			void Flush();

			void OnLostDevice();
			void OnResetDevice();

			Device^ GetDevice();

			property Matrix Transform
			{
				Matrix get();
				void set( Matrix value );
			}

			void SetWorldViewLH( Matrix world, Matrix view );
			void SetWorldViewRH( Matrix world, Matrix view );

			void Draw( Texture^ texture, System::Drawing::Rectangle sourceRect, Vector3 center, Vector3 position, int color );
			void Draw( Texture^ texture, System::Drawing::Rectangle sourceRect, Vector3 center, Vector3 position, Color color );
			void Draw( Texture^ texture, System::Drawing::Rectangle sourceRect, int color );
			void Draw( Texture^ texture, System::Drawing::Rectangle sourceRect, Color color );
			void Draw( Texture^ texture, Vector3 center, Vector3 position, int color );
			void Draw( Texture^ texture, Vector3 center, Vector3 position, Color color );
			void Draw( Texture^ texture, int color );
			void Draw( Texture^ texture, Color color );
		};
	}
}
