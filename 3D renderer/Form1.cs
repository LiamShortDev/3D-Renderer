using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Numerics;
using System.Reflection;
using System.Security;
using System.Windows.Forms;

namespace _3D_renderer
{
    public partial class Form1 : Form
    {
        public bool running = true;
        public double deltatime = 0;
        private List<SceneObject> objects = new List<SceneObject>();
        public Cube cube = new Cube(10, Color.White);
        public Sphere sphere = new Sphere(100, Color.White);
        public Sphere sphere2 = new Sphere(70, Color.Red);
        private SceneObject selectedObject;
        public Form1()
        {
            InitializeComponent();
            setDoubleBuffered(pnlDisplay);
            objects.Add(sphere);
            objects.Add(sphere2);
            objects.Add(new ProcSphere(10, Color.Blue));
            this.MouseWheel += new MouseEventHandler(Form1_MouseWheel);
        }
        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                Debug.WriteLine("Mouse wheel scrolled up");
                if (Renderer.focalLength > 10)
                {
                    Renderer.focalLength -= 2;
                }
            }
            else
            {
                // Mouse wheel scrolled down (toward the user)
                Debug.WriteLine("Mouse wheel scrolled down");
                Renderer.focalLength += 2;
            }
            Debug.WriteLine(Renderer.focalLength);
            pnlDisplay.Invalidate();

            // You can also use e.Delta to adjust zoom or movement
            // e.Delta gives the scroll amount. For most mice, this is typically 120 per scroll step.
        }
        private void setDoubleBuffered(Control control)
        {
            var propertyInfo = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);

            propertyInfo.SetValue(control, true, null);
        }

        private void pnlDisplay_Paint(object sender, PaintEventArgs e)
        {
            foreach (SceneObject obj in objects)
            {
                Renderer.RenderObject(obj, e);
            }
        }
        private void ShowTrackbars(SceneObject obj)
        {
            TrkXPos.Value = (int)obj.position.X;
            TrkYPos.Value = (int)obj.position.Y;
            TrkZPos.Value = (int)obj.position.Z;
            TrkAlpha.Value = (int)obj.rotation.Alpha;
            TrkBeta.Value = (int)obj.rotation.Beta;
            TrkGamma.Value = (int)obj.rotation.Gamma;

            txtXPos.Text = obj.position.X.ToString();
            txtYPos.Text = obj.position.Y.ToString();
            txtZPos.Text = obj.position.Z.ToString();
            txtAlphaRot.Text = obj.rotation.Alpha.ToString();
            txtBetaRot.Text = obj.rotation.Beta.ToString();
            txtGammaRot.Text = obj.rotation.Gamma.ToString();
            txtObjectType.Text = obj.GetType().Name;
            txtObjectColour.Text = ColorToHex(selectedObject.color);

            // Assign handlers AFTER clearing old ones
            TrkXPos.ValueChanged += UpdateX;
            TrkYPos.ValueChanged += UpdateY;
            TrkZPos.ValueChanged += UpdateZ;
            TrkAlpha.ValueChanged += UpdateAlpha;
            TrkBeta.ValueChanged += UpdateBeta;
            TrkGamma.ValueChanged += UpdateGamma;

            // Show trackbars
            TrkXPos.Visible = TrkYPos.Visible = TrkZPos.Visible = TrkAlpha.Visible = TrkBeta.Visible = TrkGamma.Visible = true;
            txtXPos.Visible = txtYPos.Visible = txtZPos.Visible = txtAlphaRot.Visible = txtBetaRot.Visible = txtGammaRot.Visible = true;
            lblXPos.Visible = lblYPos.Visible = lblZPos.Visible = lblAlphaRot.Visible = lblBetaRot.Visible = lblGammaRot.Visible = true;
            txtObjectType.Visible = txtObjectColour.Visible = true;
        }

        private void UpdateX(object sender, EventArgs e) { if (selectedObject != null) { selectedObject.position.X = TrkXPos.Value; pnlDisplay.Invalidate(); txtXPos.Text = TrkXPos.Value.ToString(); } }
        private void UpdateY(object sender, EventArgs e) { if (selectedObject != null) { selectedObject.position.Y = TrkYPos.Value; pnlDisplay.Invalidate(); txtYPos.Text = TrkYPos.Value.ToString(); } }
        private void UpdateZ(object sender, EventArgs e) { if (selectedObject != null) { selectedObject.position.Z = TrkZPos.Value; pnlDisplay.Invalidate(); txtZPos.Text = TrkZPos.Value.ToString(); } }
        private void UpdateAlpha(object sender, EventArgs e) { if (selectedObject != null) { selectedObject.rotation.Alpha = TrkAlpha.Value * Math.PI / 180; pnlDisplay.Invalidate(); txtAlphaRot.Text = TrkAlpha.Value.ToString(); } }
        private void UpdateBeta(object sender, EventArgs e) { if (selectedObject != null) { selectedObject.rotation.Beta = TrkBeta.Value * Math.PI / 180; pnlDisplay.Invalidate(); txtBetaRot.Text = TrkBeta.Value.ToString(); } }
        private void UpdateGamma(object sender, EventArgs e) { if (selectedObject != null) { selectedObject.rotation.Gamma = TrkGamma.Value * Math.PI / 180; pnlDisplay.Invalidate(); txtGammaRot.Text = TrkGamma.Value.ToString(); } }


        private void DeselectPreviousObject()
        {
            if (selectedObject == null) return;

            // Unsubscribe old trackbar events to prevent multiple handlers
            TrkXPos.ValueChanged -= UpdateX;
            TrkYPos.ValueChanged -= UpdateY;
            TrkZPos.ValueChanged -= UpdateZ;
            TrkAlpha.ValueChanged -= UpdateAlpha;
            TrkBeta.ValueChanged -= UpdateBeta;
            TrkGamma.ValueChanged -= UpdateGamma;

            selectedObject = null;

            // Hide trackbars
            TrkXPos.Visible = TrkYPos.Visible = TrkAlpha.Visible = TrkBeta.Visible = TrkGamma.Visible = false;
            txtXPos.Visible = txtYPos.Visible = txtAlphaRot.Visible = txtBetaRot.Visible = txtGammaRot.Visible = false;
            lblXPos.Visible = lblYPos.Visible = lblAlphaRot.Visible = lblBetaRot.Visible = lblGammaRot.Visible = false;
        }


        private void pnlDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            SceneObject newSelection = null;
            float closestDistance = float.MaxValue;

            foreach (var obj in objects)
            {
                foreach (var vertex in obj.vertices)
                {
                    // Convert vertex to 2D using your existing transformation
                    Point projected = Renderer.projectPoint(vertex, obj.size, obj.position.X, obj.position.Y, obj.position.Z);

                    if (IsNearVertex(e.Location, projected, 20)) // Adjust threshold for easier selection
                    {
                        float distance = Distance(e.Location, projected);
                        if (distance < closestDistance)
                        {
                            closestDistance = distance;
                            newSelection = obj;
                        }
                    }
                }
            }
            if (newSelection != selectedObject) // Prevent reassigning same object
            {
                DeselectPreviousObject();
                selectedObject = newSelection;

                if (selectedObject != null)
                {
                    ShowTrackbars(selectedObject);
                }
            }
        }
        private bool IsNearVertex(Point mousePos, Point projectedVertex, int threshold = 5)
        {
            return Math.Abs(mousePos.X - projectedVertex.X) < threshold &&
                   Math.Abs(mousePos.Y - projectedVertex.Y) < threshold;
        }

        private float Distance(Point p1, Point p2)
        {
            return (float)Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        private void txtXPos_TextChanged(object sender, EventArgs e)
        {
            int cursorPosition = txtXPos.SelectionStart;
            try
            {
                int x = Convert.ToInt32(txtXPos.Text);
                TrkXPos.Value = x;
            }
            catch (Exception)
            {
                txtXPos.Text = selectedObject.position.X.ToString();
            }
            txtXPos.SelectionStart = cursorPosition;
        }

        private void txtYPos_TextChanged(object sender, EventArgs e)
        {
            int cursorPosition = txtYPos.SelectionStart;
            try
            {
                int y = Convert.ToInt32(txtYPos.Text);
                TrkYPos.Value = y;
            }
            catch (Exception)
            {
                txtYPos.Text = selectedObject.position.Y.ToString();
            }
            txtYPos.SelectionStart = cursorPosition;
        }

        private void txtZPos_TextChanged(object sender, EventArgs e)
        {
            int cursorPosition = txtZPos.SelectionStart;
            try
            {
                int z = Convert.ToInt32(txtZPos.Text);
                TrkZPos.Value = z;
            }
            catch (Exception)
            {
                txtZPos.Text = selectedObject.position.Z.ToString();
            }
            txtZPos.SelectionStart = cursorPosition;
        }

        private void txtAlphaRot_TextChanged(object sender, EventArgs e)
        {
            int cursorPosition = txtAlphaRot.SelectionStart;
            try
            {
                int alpha = Convert.ToInt32(txtAlphaRot.Text);
                TrkAlpha.Value = alpha;
            }
            catch (Exception)
            {
                txtAlphaRot.Text = selectedObject.rotation.Alpha.ToString();
            }
            txtAlphaRot.SelectionStart = cursorPosition;
        }

        private void txtBetaRot_TextChanged(object sender, EventArgs e)
        {
            int cursorPosition = txtBetaRot.SelectionStart;
            try
            {
                int beta = Convert.ToInt32(txtBetaRot.Text);
                TrkBeta.Value = beta;
            }
            catch (Exception)
            {
                txtBetaRot.Text = selectedObject.rotation.Beta.ToString();
            }
            txtBetaRot.SelectionStart = cursorPosition;
        }

        private void txtGammaRot_TextChanged(object sender, EventArgs e)
        {
            int cursorPosition = txtGammaRot.SelectionStart;
            try
            {
                int gamma = Convert.ToInt32(txtGammaRot.Text);
                TrkGamma.Value = gamma;
            }
            catch (Exception)
            {
                txtGammaRot.Text = selectedObject.rotation.Gamma.ToString();
            }
            txtGammaRot.SelectionStart = cursorPosition;
        }
        private void txtObjectSize_TextChanged(object sender, EventArgs e)
        {
            int cursorPosition = txtObjectSize.SelectionStart;
            try
            {
                int size = Convert.ToInt32(txtObjectSize.Text);
                //TrkSize.Value = size;
                selectedObject.size = size;
                pnlDisplay.Invalidate(); // Redraw object with new size
            }
            catch (Exception)
            {
                txtObjectSize.Text = selectedObject.size.ToString();
            }
            txtObjectSize.SelectionStart = cursorPosition;
        }
        private void txtObjectColour_TextChanged(object sender, EventArgs e)
        {
            int cursorPosition = txtObjectColour.SelectionStart;
            string hex = txtObjectColour.Text.TrimStart('#');
            if (hex.Length == 6)
            {
                try
                {
                    int r = Convert.ToInt32(hex.Substring(0, 2), 16);
                    int g = Convert.ToInt32(hex.Substring(2, 2), 16);
                    int b = Convert.ToInt32(hex.Substring(4, 2), 16);

                    selectedObject.color = Color.FromArgb(r, g, b);
                    pnlDisplay.Invalidate(); // Redraw with new color
                }
                catch (Exception)
                {
                    // Reset to object's current color in hex format (RRGGBB)
                    txtObjectColour.Text = ColorToHex(selectedObject.color);
                }
                txtObjectColour.SelectionStart = cursorPosition;
            }
        }
        private string ColorToHex(Color color)
        {
            return $"{color.R:X2}{color.G:X2}{color.B:X2}"; // Returns "RRGGBB"
        }
        OpenFileDialog openFileDialog = new OpenFileDialog();
        private void btnLoadObject_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string Filename = openFileDialog.FileName;
                    Custom custom = new Custom(1, Color.Purple, Filename);
                    objects.Add(custom);
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }
    }
}