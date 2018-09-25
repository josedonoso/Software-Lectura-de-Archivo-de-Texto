using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace tarea_lectura_de_archivos {
    public partial class Form1 : Form {

        OpenFileDialog openFile;

        public Form1() {
            InitializeComponent();
            
            cargarComboBox();
            txtPalabras.Text = "0";
            txtCaracteres.Text = "0";
            txtEspaciosBlancos.Text = "0";
            txtTab.Text = "0";
            txtLineas.Text = "0";
            txtVocal.Text = "0";
            txtConsonantes.Text = "0";
        }
        
        private void cargarComboBox() {
            cboQuitar.Items.Insert(0, "Espacios en blanco");
            cboQuitar.Items.Insert(1, "Vocales");
            cboQuitar.Items.Insert(2, "Consonantes");
        }

        public void contarEspacios() {

            string texto = File.ReadAllText(txtRuta.Text);

            int nuevo_texto = texto.Split(new char[] { ' ' }).Length;

            txtEspaciosBlancos.Text = ""+nuevo_texto;
        }

        public void contarPalabrasArchivo() {
            int palabra = 0;
            int carac = 0;
            int linea = 0;
            StreamReader srt = new StreamReader(txtRuta.Text); //Ruta donde se encuentra mi archivo .txt
            string registro; //informacion
            registro = srt.ReadLine();
            while (registro != null) {
                carac = carac + registro.Length;
                for (int i = 0; i < registro.Length; i++) {
                    if (registro[i].ToString() == " ") //Se verifica el numero de espacios
                    {
                        palabra++;
                    }
                    
                }
                palabra++; // Se suma uno de mas ya que la ultima palabra no tiene espacio
                registro = srt.ReadLine();
                linea = linea + 1;
            }


            txtPalabras.Text = "" + palabra;
            txtCaracteres.Text = "" + carac;
            txtLineas.Text = "" + linea;
        }

        public void contarConsonantes() {
            string cadena = File.ReadAllText(txtRuta.Text);

            int consonante = 0;

            for (int v = 0; v < cadena.Length; v++) {
                if ((cadena[v] == 'b') || (cadena[v] == 'c') || (cadena[v] == 'd') || (cadena[v] == 'f') || (cadena[v] == 'g') ||
                    (cadena[v] == 'h') || (cadena[v] == 'j') || (cadena[v] == 'k') || (cadena[v] == 'l') || (cadena[v] == 'm') ||
                    (cadena[v] == 'n') || (cadena[v] == 'ñ') || (cadena[v] == 'p') || (cadena[v] == 'q') || (cadena[v] == 'r') ||
                    (cadena[v] == 's') || (cadena[v] == 't') || (cadena[v] == 'v') || (cadena[v] == 'w') || (cadena[v] == 'x') ||
                    (cadena[v] == 'y') || (cadena[v] == 'z')
                    ) {
                    consonante++;
                    txtConsonantes.Text = consonante.ToString();
                }
            }
        }

        public void contarVocales() {
            string cadena = File.ReadAllText(txtRuta.Text);

            int vocal = 0;

            for (int v = 0; v < cadena.Length; v++) {
                if ((cadena[v] == 'a') || (cadena[v] == 'e') || (cadena[v] == 'i') || (cadena[v] == 'o') || (cadena[v] == 'u')) {
                    vocal++;
                    txtVocal.Text = vocal.ToString();
                }

            }

        }

        private void btnGuardar_Click(object sender, EventArgs e) {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.InitialDirectory = "c:\\";
            saveFile.Filter = "Archivos txt (*.txt) |*.txt";
            saveFile.FilterIndex = 2;
            saveFile.RestoreDirectory = true;
            if (saveFile.ShowDialog() == DialogResult.OK) {
                using (Stream s = File.Open(saveFile.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s)) {
                    sw.Write(txtArchivo.Text);
                    txtArchivo.Text = "";
                }
            }
        }

        public int getLineas() {
            if (txtArchivo.Text.Equals("")) {
                return 0;
            } else {
                String valor;
                valor = txtArchivo.Text.Split().Length.ToString();
                
                txtLineas.Text = valor;
            }
            return 0;
        }

        private void txtArchivo_TextChanged(object sender, EventArgs e) {

            int vocal;
            vocal = 0;
            //Contador de caracteres
            for (int c = 0; c <= txtArchivo.TextLength; c++) {
                txtCaracteres.Text = c.ToString();
                //Console.WriteLine("Caracteres: " + c.ToString());
            }
            
            //Contador de vocales
            string cadena;
            cadena = @txtArchivo.Text;
            for (int v = 0; v < cadena.Length; v++) {
                if ((cadena[v] == 'a') || (cadena[v] == 'e') || (cadena[v] == 'i') || (cadena[v] == 'o') || (cadena[v] == 'u')) {
                    vocal++;
                    txtVocal.Text = vocal.ToString();
                }

            }

            //Contador de espacios en blanco
            int espacio = 0;
            for (int espacio_blanco = 0; espacio_blanco < cadena.Length; espacio_blanco++) {
                if (cadena[espacio_blanco] == ' ') {
                    espacio++;
                    txtEspaciosBlancos.Text = espacio.ToString();
                } 

                
            }

            //Contador de consonantes
            int consonante = 0;
            for (int v = 0; v < txtArchivo.TextLength; v++) {
                if ((cadena[v] == 'b') || (cadena[v] == 'c') || (cadena[v] == 'd') || (cadena[v] == 'f') || (cadena[v] == 'g') ||
                    (cadena[v] == 'h') || (cadena[v] == 'j') || (cadena[v] == 'k') || (cadena[v] == 'l') || (cadena[v] == 'm') ||
                    (cadena[v] == 'n') || (cadena[v] == 'ñ') || (cadena[v] == 'p') || (cadena[v] == 'q') || (cadena[v] == 'r') ||
                    (cadena[v] == 's') || (cadena[v] == 't') || (cadena[v] == 'v') || (cadena[v] == 'w') || (cadena[v] == 'x') ||
                    (cadena[v] == 'y') || (cadena[v] == 'z')
                    ) {
                    consonante++;
                    txtConsonantes.Text = consonante.ToString();
                }
            }

            //Contador de vocales
            for (int v = 0; v < txtArchivo.TextLength; v++) {
                if ((cadena[v] == 'a') || (cadena[v] == 'e') || (cadena[v] == 'i') || (cadena[v] == 'o') || (cadena[v] == 'u')) {
                    vocal++;
                    txtVocal.Text = vocal.ToString();
                }
            }

            //Contador de lineas
            getLineas();

            //Contador de tabuladores
            int tab = 0;
            for (int v = 0; v < txtArchivo.Text.Length; v++) {
                if ((cadena[v] == '\n')) {
                    tab++;
                    //Console.WriteLine(tab);
                    txtTab.Text = tab.ToString();
                }

            }

            //Contador de palabras
            contarPalabrasTexto();

        }

        private void btnExaminar_Click(object sender, EventArgs e) {
            Stream myStream;
            openFile = new OpenFileDialog();

            openFile.InitialDirectory = "c:\\";
            openFile.Filter = "Archivos txt (*.txt) |*.txt";
            openFile.FilterIndex = 2;
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                if ((myStream = openFile.OpenFile()) != null) {
                    string strfilename = openFile.FileName;
                    string filetext = File.ReadAllText(strfilename);
                    //Console.WriteLine();
                    txtArchivo.Text = filetext;
                    txtRuta.Text = strfilename;
                    contarEspacios();
                    contarPalabrasArchivo();
                    contarVocales();
                    contarConsonantes();
                    contarTab();
                    contarLineasTexto();
                }
            }
            openFile.Dispose();
        }

        private int contarLineasTexto() {
            if (txtArchivo.Text.Equals("")) {
                return 0;
            } else {
                String archivo = txtArchivo.Text;
                char[] archivoNuevo = txtArchivo.Text.ToCharArray();
                //Console.WriteLine(archivoNuevo);
            }
            return 0;
        }

        private void contarTab() {
            String cadena;
            int tab = 0;
            cadena = @txtArchivo.Text;
            for (int v = 0; v < cadena.Length; v++) {
                if ((cadena[v] == '\n')) {
                    tab++;
                    //Console.WriteLine(tab);
                    txtTab.Text = tab.ToString();
                }

            }
        }

        private void btnProcesar_Click(object sender, EventArgs e) {
            if (cboQuitar.SelectedIndex == 0) {
                //MessageBox.Show("Espacios en blanco");

                string texto = txtArchivo.Text.Replace(" ", "");


                string cadena = texto.Replace(" ","");
                txtArchivo.Text = texto;

                int nuevo_texto = texto.Split(new char[] { ' ' }).Length;

                txtEspaciosBlancos.Text = "" + nuevo_texto;

            } else if (cboQuitar.SelectedIndex == 1) {

                string cadena = @txtArchivo.Text;

                string texto = Regex.Replace(cadena, "[a,e,i,o,u,A,E,I,O,U]", "", RegexOptions.None);


                txtArchivo.Text = texto;

                int vocal;
                vocal = 0;

                for (int v = 0; v < txtArchivo.TextLength; v++) {
                    if ((cadena[v] == 'a') || (cadena[v] == 'e') || (cadena[v] == 'i') || (cadena[v] == 'o') || (cadena[v] == 'u')) {
                        vocal++;
                        txtVocal.Text = vocal.ToString();
                    }
                }


            } else if (cboQuitar.SelectedIndex == 2) {
                 string cadena = @txtArchivo.Text.ToLower();

                string texto = Regex.Replace(cadena, "[b,c,d,f,g,h,j,k,l,m,n,ñ,p,q,r,s,t,v,w,x,y,z]", "", RegexOptions.None);

                txtArchivo.Text = texto;

                int consonante = 0;

                for (int v = 0; v < txtArchivo.TextLength; v++) {
                    if ((cadena[v] == 'b') || (cadena[v] == 'c') || (cadena[v] == 'd') || (cadena[v] == 'f') || (cadena[v] == 'g') ||
                        (cadena[v] == 'h') || (cadena[v] == 'j') || (cadena[v] == 'k') || (cadena[v] == 'l') || (cadena[v] == 'm') ||
                        (cadena[v] == 'n') || (cadena[v] == 'ñ') || (cadena[v] == 'p') || (cadena[v] == 'q') || (cadena[v] == 'r') ||
                        (cadena[v] == 's') || (cadena[v] == 't') || (cadena[v] == 'v') || (cadena[v] == 'w') || (cadena[v] == 'x') ||
                        (cadena[v] == 'y') || (cadena[v] == 'z')
                        ) {
                        consonante++;
                        txtConsonantes.Text = consonante.ToString();
                    }
                }
            }
        }

        private void btn(object sender, EventArgs e) {
            Stream myStream;
            openFile = new OpenFileDialog();

            openFile.InitialDirectory = "c:\\";
            openFile.Filter = "Archivos txt (*.txt) |*.txt";
            openFile.FilterIndex = 2;
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                if ((myStream = openFile.OpenFile()) != null) {
                    string strfilename = openFile.FileName;
                    string filetext = File.ReadAllText(strfilename);
                    txtArchivo.Text = filetext;
                    txtRuta.Text = openFile.FileName;
                    contarEspacios();
                    //contarPalabras();
                    contarVocales();
                    contarConsonantes();
                    contarTab();
                }
            }
            openFile.Dispose();
        }

       
    }
}
