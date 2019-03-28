using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;

using System.Windows.Media;
using System.Windows.Media.Media3D;

using HelixToolkit;
using HelixToolkit.Wpf;

using MeshMaker;
using System.Windows.Controls.Primitives;
using Xceed.Wpf.Toolkit;
using MaterialDesignColors;

namespace MeshMakerViewer
{
    public class MeshViewer
    {

        #region members

        Window window = new Window();
        StackPanel container = new StackPanel();

        ColorPicker picker = new ColorPicker();

        HelixViewport3D viewport = new HelixViewport3D();
        int width = 400;
        int height = 400;
        System.Windows.Media.Color modelColor = Colors.LightBlue;

        DiffuseMaterial material = new DiffuseMaterial();

        List<Mesh> meshes = new List<Mesh>();

        #endregion

        #region constructors

        public MeshViewer()
        {
            
        }

        public MeshViewer(Mesh mesh)
        {
            meshes.Add(mesh);
        }

        #endregion

        #region members
        
        public void SetControls()
        {
            picker.SelectedColor = modelColor;
            picker.SelectedColorChanged -= (o, e) => { SetMaterialColor(); };
            picker.SelectedColorChanged += (o, e) => { SetMaterialColor(); };
        }

        public void SetMaterialColor()
        {
            MaterialDesignColors.Hue swatch = new MaterialDesignColors.Hue("Name",Colors.Red,Colors.Black);
            modelColor = picker.SelectedColor.Value;
            material.Brush = new SolidColorBrush(modelColor);
        }

        public void SetViewer()
        {

            window.Width = width+50;
            window.Height = height+200;
            container.Width = width;
            viewport.Width = width;

            viewport.Height = height;
        }

        public void SetModel()
        {
            SetMaterialColor();
            ModelVisual3D VisD = new ModelVisual3D();
            Model3DGroup models = new Model3DGroup();

            foreach(Mesh mesh in meshes)
            {
                GeometryModel3D mGeo = new GeometryModel3D(mesh.ToMediaMesh(),material);
                
                models.Children.Add(mGeo);
            }

            VisD.Content = models;
            
            viewport.Children.Clear();

            viewport.Children.Add(new GridLinesVisual3D());
            viewport.Children.Add(new DefaultLights());
            viewport.Children.Add(VisD);
        }

        public void BuildViewer()
        {
            window.Close();
            window = new Window();
            SetViewer();
            SetControls();
            SetModel();

            container.Children.Add(viewport);
            container.Children.Add(picker);

            window.Content = container;

            window.Show();
        }

        #endregion


    }
}
