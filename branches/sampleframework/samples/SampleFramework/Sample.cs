﻿/*
* Copyright (c) 2007-2009 SlimDX Group
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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using SlimDX.Windows;

namespace SlimDX.SampleFramework
{
	/// <summary>
	/// Implements core application logic of a SlimDX sample.
	/// 
	/// The Sample class provides a minimal wrapper around window setup, user
	/// interaction, and OS-level details, but provides very little abstraction
	/// of the underlying DirectX functionality. The reason for this is that the 
	/// purpose of a SlimDX sample is to illustrate how a particular technique 
	/// might be implemented using SlimDX; providing high level rendering abstractions
	/// in the sample framework simplify obfuscates that.
	/// 
	/// A sample is implemented by overriding various base class methods (those prefixed
	/// with "on"). 
	/// </summary>
	public class Sample : IDisposable
	{
		#region Public Interface
		
		/// <summary>
		/// Gets the width of the renderable area of the sample window.
		/// </summary>
		public int WindowWidth
		{
			get
			{
				return configuration.WindowWidth;
			}
		}

		/// <summary>
		/// Gets the height of the renderable area of the sample window.
		/// </summary>
		public int WindowHeight
		{
			get
			{
				return configuration.WindowHeight;
			}
		}

		public UserInterface UserInterface
		{
			get
			{
				return userInterface;
			}
		}

		/// <summary>
		/// Disposes of object resources.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Disposes of object resources.
		/// </summary>
		/// <param name="disposeManagedResources">If true, managed resources should be
		/// disposed of in addition to unmanaged resources.</param>
		protected virtual void Dispose(bool disposeManagedResources)
		{
			if (disposeManagedResources)
			{
				context.Dispose();
				form.Dispose();
			}
		}

		/// <summary>
		/// Runs the sample.
		/// </summary>
		public void Run()
		{
			configuration = OnConfigure();
			form = new RenderForm(configuration.WindowTitle)
			{
				ClientSize = new Size(configuration.WindowWidth, configuration.WindowHeight)
			};

			form.MouseClick += HandleMouseClick;
			
			userInterface = new UserInterface();
			userInterface.Container.Add( new Element { Label = configuration.WindowTitle } );
			
			OnInitialize();

			MessagePump.Run(form, () =>
			{
				Update();
				Render();
			});
		}

		/// <summary>
		/// In a derived class, implements logic to control the configuration of the sample
		/// via a <see cref="SampleConfiguration"/> object.
		/// </summary>
		/// <returns>A <see cref="SampleConfiguration"/> object describing the desired configuration of the sample.</returns>
		protected virtual SampleConfiguration OnConfigure()
		{
			return new SampleConfiguration();
		}

		/// <summary>
		/// In a derived class, implements logic to initialize the sample.
		/// </summary>
		protected virtual void OnInitialize()
		{
		}

		/// <summary>
		/// In a derived class, implements logic to update any relevant sample state.
		/// </summary>
		protected virtual void OnUpdate()
		{
		}

		/// <summary>
		/// In a derived class, implements logic to render the sample.
		/// </summary>
		protected virtual void OnRender()
		{
		}

		/// <summary>
		/// In a derived class, implements logic that should occur before all
		/// other rendering.
		/// </summary>
		protected virtual void OnRenderBegin()
		{
		}

		/// <summary>
		/// In a derived class, implements logic that should occur after all
		/// other rendering.
		/// </summary>
		protected virtual void OnRenderEnd()
		{
		}

		/// <summary>
		/// Initializes a <see cref="DeviceContext9">Direct3D9 device context</see> according to the specified settings.
		/// The base class retains ownership of the context and will dispose of it when appropriate.
		/// </summary>
		/// <param name="settings">The settings.</param>
		/// <returns>The initialized device context.</returns>
		protected DeviceContext9 InitializeDevice(DeviceSettings9 settings)
		{
			context = new DeviceContext9(form.Handle, settings);
			userInterfaceRenderer = new UserInterfaceRenderer9( context.Device, settings.Width, settings.Height );
			return context;
		}

		/// <summary>
		/// Quits the sample.
		/// </summary>
		protected void Quit()
		{
			form.Close();
		}
		
		#endregion
		#region Implementation Detail

		RenderForm form;
		SampleConfiguration configuration;

		UserInterface userInterface;
		UserInterfaceRenderer userInterfaceRenderer;

		DeviceContext9 context;

		/// <summary>
		/// Performs object finalization.
		/// </summary>
		~Sample()
		{
			Dispose(false);
		}

		/// <summary>
		/// Updates sample state.
		/// </summary>
		void Update()
		{
			OnUpdate();
		}

		/// <summary>
		/// Renders the sample.
		/// </summary>
		void Render()
		{
			OnRenderBegin();
			OnRender();
			userInterfaceRenderer.Render(userInterface);
			OnRenderEnd();
		}

		/// <summary>
		/// Handles a mouse click event.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
		void HandleMouseClick(object sender, MouseEventArgs e)
		{
		}

		#endregion
	}
}