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

namespace SlimDX
{
	ref class DataStream;

	namespace Direct3D9
	{
		[Flags]
		public enum class MeshFlags : Int32
		{
			Use32Bit = D3DXMESH_32BIT,
			DoNotClip = D3DXMESH_DONOTCLIP,
			Points = D3DXMESH_POINTS,
			RTPatches = D3DXMESH_RTPATCHES,
			NPatches = D3DXMESH_NPATCHES,
			VertexBufferSystemMemory = D3DXMESH_VB_SYSTEMMEM,
			VertexBufferManaged = D3DXMESH_VB_MANAGED,
			VertexBufferWriteOnly = D3DXMESH_VB_WRITEONLY,
			VertexBufferDynamic = D3DXMESH_VB_DYNAMIC,
			VertexBufferSoftware = D3DXMESH_VB_SOFTWAREPROCESSING,
			IndexBufferSystemMemory = D3DXMESH_IB_SYSTEMMEM,
			IndexBufferManaged = D3DXMESH_IB_MANAGED,
			IndexBufferbWriteOnly = D3DXMESH_IB_WRITEONLY,
			IndexBufferDynamic = D3DXMESH_IB_DYNAMIC,
			IndexBufferSoftware = D3DXMESH_IB_SOFTWAREPROCESSING,

			VertexBufferShare = D3DXMESH_VB_SHARE,

			UseHardwareOnly = D3DXMESH_USEHWONLY,

			// Helper options
			SystemMemory = D3DXMESH_SYSTEMMEM,
			Managed = D3DXMESH_MANAGED,
			WriteOnly = D3DXMESH_WRITEONLY,
			Dynamic = D3DXMESH_DYNAMIC,
			Software = D3DXMESH_SOFTWAREPROCESSING,
		};

		[Flags]
		public enum class TangentOptions : Int32
		{
			None = 0,
			WrapU = D3DXTANGENT_WRAP_U,
			WrapV = D3DXTANGENT_WRAP_V,
			WrapUV = D3DXTANGENT_WRAP_UV,
			DontNormalizePartials = D3DXTANGENT_DONT_NORMALIZE_PARTIALS,
			DontOrthogonalize = D3DXTANGENT_DONT_ORTHOGONALIZE,
			OrthogonalizeFromV = D3DXTANGENT_ORTHOGONALIZE_FROM_V,
			OrthogonalizeFromU = D3DXTANGENT_ORTHOGONALIZE_FROM_U,
			WeightByArea = D3DXTANGENT_WEIGHT_BY_AREA,
			WeightEqual = D3DXTANGENT_WEIGHT_EQUAL,
			WindCW = D3DXTANGENT_WIND_CW,
			CalculateNormals = D3DXTANGENT_CALCULATE_NORMALS,
			GenerateInPlace = D3DXTANGENT_GENERATE_IN_PLACE,
		};

		public enum class EffectDefaultType : Int32
		{
			String = D3DXEDT_STRING,
			Floats = D3DXEDT_FLOATS,
			Dword = D3DXEDT_DWORD,
		};

		[Flags]
		public enum class MeshOptimizeFlags : Int32
		{
			Compact = D3DXMESHOPT_COMPACT,
			AttributeSort = D3DXMESHOPT_ATTRSORT,
			VertexCache = D3DXMESHOPT_VERTEXCACHE,
			StripReorder = D3DXMESHOPT_STRIPREORDER,
			IgnoreVertices = D3DXMESHOPT_IGNOREVERTS,
			DoNotSplit = D3DXMESHOPT_DONOTSPLIT,
			DeviceIndependent = D3DXMESHOPT_DEVICEINDEPENDENT,
		};

		public enum class PatchMeshType : Int32
		{
			Rectangle = D3DXPATCHMESH_RECT,
			Triangle = D3DXPATCHMESH_TRI,
			NPatch = D3DXPATCHMESH_NPATCH
		};

		public value class ExtendedMaterial
		{
		internal:
			static D3DXMATERIAL ToUnmanaged( ExtendedMaterial material );
			static ExtendedMaterial FromUnmanaged( const D3DXMATERIAL &material );
			static array<ExtendedMaterial>^ FromBuffer( ID3DXBuffer* buffer, unsigned int count );

		public:
			property Material MaterialD3D;
			property String^ TextureFilename;
		};

		public value class EffectDefault
		{
		public:
			property String^ ParameterName;
			property EffectDefaultType Type;
			property DataStream^ Value;
		};

		public value class EffectInstance
		{
		internal:
			static EffectInstance FromUnmanaged( const D3DXEFFECTINSTANCE &effect );
			static D3DXEFFECTINSTANCE ToUnmanaged( EffectInstance effect );
			static array<EffectInstance>^ FromBuffer( ID3DXBuffer* buffer, unsigned int count );

		public:
			property String^ EffectFilename;
			property array<EffectDefault>^ Defaults;
		};

		public value class AttributeRange
		{
		public:
			property int AttribId;
			property int FaceStart;
			property int FaceCount;
			property int VertexStart;
			property int VertexCount;
		};

		public value class PatchInfo
		{
		public:
			property PatchMeshType PatchType;
			property Degree Degree;
			property Basis Basis;
		};

		public value class DisplacementParameters
		{
		public:
			property Texture^ Texture;
			property TextureFilter MinFilter;
			property TextureFilter MagFilter;
			property TextureFilter MipFilter;
			property TextureAddress Wrap;
			property int LevelOfDetailBias;
		};

		ref class StreamShim : System::Runtime::InteropServices::ComTypes::IStream
		{
		private:
			Stream^ m_WrappedStream;

			long long position;
			void SetSizeToPosition();

		public:
			StreamShim( Stream^ stream );

			virtual void Clone( [Out] System::Runtime::InteropServices::ComTypes::IStream^% ppstm );
			virtual void Commit( int grfCommitFlags );
			virtual void CopyTo( System::Runtime::InteropServices::ComTypes::IStream^ pstm, long long cb, IntPtr pcbRead, IntPtr pcbWritten );
			virtual void LockRegion( long long libOffset, long long cb, int dwLockType );
			virtual void Read( [Out] array<unsigned char>^ pv, int cb, IntPtr pcbRead );
			virtual void Revert();
			virtual void Seek( long long dlibMove, int dwOrigin, IntPtr plibNewPosition );
			virtual void SetSize( long long libNewSize );
			virtual void Stat( [Out] System::Runtime::InteropServices::ComTypes::STATSTG% pstatstg, int grfStatFlag );
			virtual void UnlockRegion( long long libOffset, long long cb, int dwLockType );
			virtual void Write( array<unsigned char>^ pv, int cb, IntPtr pcbWritten );
		};

		ref class Mesh;
		ref class VertexBuffer;
		ref class IndexBuffer;
		ref class BufferWrapper;
		enum class VertexFormat;

		public ref class BaseMesh abstract : public DirectXObject<ID3DXBaseMesh>
		{
		protected:
			BaseMesh() { }
			BaseMesh( ID3DXBaseMesh* baseMesh ) : DirectXObject( baseMesh )
			{ }

		public:
			Mesh^ Clone( Device^ device, MeshFlags flags, array<VertexElement>^ elements );
			Mesh^ Clone( Device^ device, MeshFlags flags, VertexFormat fvf );
			virtual ~BaseMesh() { Destruct(); }
			DXOBJECT_FUNCTIONS;

			Device^ GetDevice();
			IndexBuffer^ GetIndexBuffer();
			VertexBuffer^ GetVertexBuffer();
			array<VertexElement>^ GetDeclaration();
			array<AttributeRange>^ GetAttributeTable();

			DataStream^ LockIndexBuffer( LockFlags flags );
			void UnlockIndexBuffer();

			DataStream^ LockVertexBuffer( LockFlags flags );
			void UnlockVertexBuffer();

			array<int>^ GenerateAdjacency( float epsilon );
			array<int>^ ConvertAdjacencyToPointReps( array<int>^ adjacency );
			array<int>^ ConvertPointRepsToAdjacency( array<int>^ adjacency );
			void UpdateSemantics( array<VertexElement>^ elements );

			void DrawSubset( int subset );

			property int FaceCount { int get(); }
			property int VertexCount { int get(); }
			property VertexFormat VertexFormat { SlimDX::Direct3D9::VertexFormat get(); }
			property int BytesPerVertex { int get(); }
			property MeshFlags CreationOptions { MeshFlags get(); }
		};

		public ref class Mesh : public BaseMesh
		{
		internal:
			Mesh( ID3DXMesh* mesh );
			property ID3DXMesh* MeshPointer
			{
				ID3DXMesh* get() { return static_cast<ID3DXMesh*>( m_Pointer ); }
			}

		public:
			Mesh( Device^ device, int faceCount, int vertexCount, MeshFlags options, array<VertexElement>^ vertexDecl );
			Mesh( Device^ device, int faceCount, int vertexCount, MeshFlags options, SlimDX::Direct3D9::VertexFormat fvf );
			virtual ~Mesh() { }
			
			static Mesh^ FromMemory( Device^ device, array<Byte>^ memory, MeshFlags flags, [Out] BufferWrapper^% adjacency,
				[Out] array<ExtendedMaterial>^% materials, [Out] array<EffectInstance>^% effectInstances );
			static Mesh^ FromMemory( Device^ device, array<Byte>^ memory, MeshFlags flags, [Out] array<ExtendedMaterial>^% materials,
				[Out] array<EffectInstance>^% effectInstances );
			static Mesh^ FromMemory( Device^ device, array<Byte>^ memory, MeshFlags flags, [Out] array<ExtendedMaterial>^% materials );
			static Mesh^ FromMemory( Device^ device, array<Byte>^ memory, MeshFlags flags );

			static Mesh^ FromStream( Device^ device, Stream^ stream, MeshFlags flags, [Out] BufferWrapper^% adjacency,
				[Out] array<ExtendedMaterial>^% materials, [Out] array<EffectInstance>^% effectInstances );
			static Mesh^ FromStream( Device^ device, Stream^ stream, MeshFlags flags, [Out] array<ExtendedMaterial>^% materials,
				[Out] array<EffectInstance>^% effectInstances );
			static Mesh^ FromStream( Device^ device, Stream^ stream, MeshFlags flags, [Out] array<ExtendedMaterial>^% materials );
			static Mesh^ FromStream( Device^ device, Stream^ stream, MeshFlags flags );

			static Mesh^ FromFile( Device^ device, String^ fileName, MeshFlags flags, [Out] BufferWrapper^% adjacency,
				[Out] array<ExtendedMaterial>^% materials, [Out] array<EffectInstance>^% effectInstances );
			static Mesh^ FromFile( Device^ device, String^ fileName, MeshFlags flags, [Out] array<ExtendedMaterial>^% materials,
				[Out] array<EffectInstance>^% effectInstances );
			static Mesh^ FromFile( Device^ device, String^ fileName, MeshFlags flags, [Out] array<ExtendedMaterial>^% materials );
			static Mesh^ FromFile( Device^ device, String^ fileName, MeshFlags flags );

			/*static Mesh^ CreateBox( Device^ device, float width, float height, float depth, [Out] BufferWrapper^% adjacency );
			static Mesh^ CreateBox( Device^ device, float width, float height, float depth );

			static Mesh^ CreateCylinder( Device^ device, float radius1, float radius2, float length, int slices, int stacks, [Out] BufferWrapper^% adjacency );
			static Mesh^ CreateCylinder( Device^ device, float radius1, float radius2, float length, int slices, int stacks );

			static Mesh^ CreateSphere( Device^ device, float radius, int slices, int stacks, [Out] BufferWrapper^% adjacency );
			static Mesh^ CreateSphere( Device^ device, float radius, int slices, int stacks );

			static Mesh^ CreateTeapot( Device^ device, [Out] BufferWrapper^% adjacency );
			static Mesh^ CreateTeapot( Device^ device );

			//TODO: CreateText overload that returns glyph metrics
			static Mesh^ CreateText( Device^ device, IntPtr hDC, String^ text, float deviation, float extrusion, [Out] BufferWrapper^% adjacency );
			static Mesh^ CreateText( Device^ device, IntPtr hDC, String^ text, float deviation, float extrusion );

			static Mesh^ CreateTorus( Device^ device, float innerRadius, float outerRadius, int sides, int rings, [Out] BufferWrapper^% adjacency );
			static Mesh^ CreateTorus( Device^ device, float innerRadius, float outerRadius, int sides, int rings );

			//DataStream^ LockAttributeBuffer( LockFlags flags );
			//void UnlockAttributeBuffer();

			void OptimizeInPlace( MeshOptimizeFlags flags, IntPtr adjacencyIn, [Out] array<int>^% adjacencyOut,
				[Out] array<int>^% faceRemap, [Out] BufferWrapper^% vertexRemap );
			void OptimizeInPlace( MeshOptimizeFlags flags, IntPtr adjacencyIn, [Out] array<int>^% faceRemap,
				[Out] BufferWrapper^% vertexRemap );
			void OptimizeInPlace( MeshOptimizeFlags flags, IntPtr adjacencyIn, [Out] array<int>^% adjacencyOut );
			void OptimizeInPlace( MeshOptimizeFlags flags, IntPtr adjacencyIn );

			void OptimizeInPlace( MeshOptimizeFlags flags, array<int>^ adjacencyIn, [Out] array<int>^% adjacencyOut,
				[Out] array<int>^% faceRemap, [Out] BufferWrapper^% vertexRemap );
			void OptimizeInPlace( MeshOptimizeFlags flags, array<int>^ adjacencyIn, [Out] array<int>^% faceRemap,
				[Out] BufferWrapper^% vertexRemap );
			void OptimizeInPlace( MeshOptimizeFlags flags, array<int>^ adjacencyIn, [Out] array<int>^% adjacencyOut );
			void OptimizeInPlace( MeshOptimizeFlags flags, array<int>^ adjacencyIn );

			Mesh^ Optimize( MeshOptimizeFlags flags, IntPtr adjacencyIn, [Out] array<int>^% adjacencyOut,
				[Out] array<int>^% faceRemap, [Out] BufferWrapper^% vertexRemap );
			Mesh^ Optimize( MeshOptimizeFlags flags, IntPtr adjacencyIn, [Out] array<int>^% faceRemap,
				[Out] BufferWrapper^% vertexRemap );
			Mesh^ Optimize( MeshOptimizeFlags flags, IntPtr adjacencyIn, [Out] array<int>^% adjacencyOut );
			Mesh^ Optimize( MeshOptimizeFlags flags, IntPtr adjacencyIn );

			Mesh^ Optimize( MeshOptimizeFlags flags, array<int>^ adjacencyIn, [Out] array<int>^% adjacencyOut,
				[Out] array<int>^% faceRemap, [Out] BufferWrapper^% vertexRemap );
			Mesh^ Optimize( MeshOptimizeFlags flags, array<int>^ adjacencyIn, [Out] array<int>^% faceRemap,
				[Out] BufferWrapper^% vertexRemap );
			Mesh^ Optimize( MeshOptimizeFlags flags, array<int>^ adjacencyIn, [Out] array<int>^% adjacencyOut );
			Mesh^ Optimize( MeshOptimizeFlags flags, array<int>^ adjacencyIn );*/

			void ComputeTangentFrame( TangentOptions options );
		};

		public ref class ProgressiveMesh : public BaseMesh
		{
		internal:
			ProgressiveMesh( ID3DXPMesh* mesh ) : BaseMesh( mesh ) { }

			property ID3DXPMesh* MeshPointer
			{
				ID3DXPMesh* get() { return static_cast<ID3DXPMesh*>( m_Pointer ); }
			}

		public:
			virtual ~ProgressiveMesh() { }

			ProgressiveMesh^ CloneProgressive( Device^ device, MeshFlags flags, array<VertexElement>^ vertexDeclaration );
			ProgressiveMesh^ CloneProgressive( Device^ device, MeshFlags flags, SlimDX::Direct3D9::VertexFormat format );

			void GenerateVertexHistory( array<int>^ vertexHistory );
			array<int>^ GetAdjacency();
		
			Mesh^ Optimize( MeshOptimizeFlags flags );
			Mesh^ Optimize( MeshOptimizeFlags flags, [Out] array<int>^% adjacencyOut );
			Mesh^ Optimize( MeshOptimizeFlags flags, [Out] array<int>^% faceRemap, [Out] BufferWrapper^% vertexRemap );
			Mesh^ Optimize( MeshOptimizeFlags flags, [Out] array<int>^% adjacencyOut, [Out] array<int>^% faceRemap, [Out] BufferWrapper^% vertexRemap );

			void OptimizeBaseLevelOfDetail( MeshOptimizeFlags flags );
			void OptimizeBaseLevelOfDetail( MeshOptimizeFlags flags, [Out] array<int>^% faceRemap );

			void Save( Stream^ stream, array<ExtendedMaterial>^ materials, array<EffectInstance>^ effects );
			void SetFaceCount( int faceCount );
			void SetVertexCount( int vertexCount );

			void TrimFaces( int newFaceMinimum, int newFaceMaximum );
			void TrimFaces( int newFaceMinimum, int newFaceMaximum, [Out] array<int>^% faceRemap, [Out] array<int>^% vertexRemap );
			void TrimVertices( int newVertexMinimum, int newVertexMaximum );
			void TrimVertices( int newVertexMinimum, int newVertexMaximum, [Out] array<int>^% faceRemap, [Out] array<int>^% vertexRemap );

			property int MaximumFaceCount { int get(); }
			property int MaximumVertexCount { int get(); }
			property int MinimumFaceCount { int get(); }
			property int MinimumVertexCount { int get(); }
		};

		public ref class PatchMesh : DirectXObject<ID3DXPatchMesh>
		{
		internal:
			PatchMesh( ID3DXPatchMesh *mesh ) : DirectXObject( mesh ) { }

		public:
			PatchMesh( Device^ device, PatchInfo info, int patchCount, int vertexCount, array<VertexElement>^ vertexDeclaration );
			virtual ~PatchMesh() { Destruct(); }
			DXOBJECT_FUNCTIONS;

			PatchMesh^ Clone( MeshFlags flags, array<VertexElement>^ vertexDeclaration );
			void GenerateAdjacency( float tolerance );

			array<VertexElement>^ GetDeclaration();
			Device^ GetDevice();
			IndexBuffer^ GetIndexBuffer();
			VertexBuffer^ GetVertexBuffer();
			PatchInfo GetPatchInfo();
			void Optimize();

			DisplacementParameters GetDisplacementParameters();
			void SetDisplacementParameters( DisplacementParameters parameters );

			DataStream^ LockAttributeBuffer( LockFlags flags );
			void UnlockAttributeBuffer();

			DataStream^ LockIndexBuffer( LockFlags flags );
			void UnlockIndexBuffer();

			DataStream^ LockVertexBuffer( LockFlags flags );
			void UnlockVertexBuffer();

			void GetTessellationSize( float tessellationLevel, bool adaptive, [Out] int% triangleCount, [Out] int% vertexCount );
			void Tessellate( float tessellationLevel, Mesh^ mesh );
			void Tessellate( Vector4 translation, int minimumLevel, int maximumLevel, Mesh^ mesh );

			property int ControlVerticesPerPatch { int get(); }
			property int PatchCount { int get(); }
			property int VertexCount { int get(); }
			property PatchMeshType Type { PatchMeshType get(); }
		};
	}
}
