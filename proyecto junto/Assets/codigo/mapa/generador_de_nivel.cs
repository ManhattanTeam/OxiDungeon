using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generador_de_nivel : MonoBehaviour
 {
	public GameObject baldosa;
	public GameObject pared;
	public GameObject pared_top;
	public GameObject suelo;
	public GameObject columna;
	public GameObject puertaV;
	public GameObject puertaH;
	public GameObject [,] sala;
	public GameObject jugador;
	public Camera camara;
	private GameObject [] puertas;
	private int columnas;
	private int Nsalas;
	private int auxX = 0;
	private int auxY = 0;
	private int posicion;
	private int filas;
    private int tag;
	private bool bloqueo = false;
	private int cont1, cont2;
	private int contpuentes = 0;
	private int salamedio;


    // Use this for initialization
    void Awake () {
		cont1 = cont2 = 0;
		sala = new GameObject[500, 500];
		Nsalas = Random.Range(5,9);
		puertas = new GameObject[Nsalas - 1];
		salamedio = (int)(Nsalas/2);
		
		
		
		for(int salas = 0; salas < Nsalas; salas ++){
			columnas = Random.Range(9,37);
	    	filas = Random.Range(8,36);
            tag = salas;
            
			
			for(int i = 0 + auxX; i < columnas + auxX ;i ++){

				for(int j = 0 + auxY; j < filas + auxY /*&& bloqueo == false*/; j ++){

					if(i == 0 + auxX || j == 0 + auxY || i == (columnas + auxX) -1 || j == (filas + auxY) - 1){

						
						
                        baldosa.layer = 8;
						baldosa.GetComponent<BoxCollider2D>().isTrigger = false;
						if(i == 0 + auxX){
							baldosa.GetComponent<SpriteRenderer>().sprite = pared.GetComponent<SpriteRenderer>().sprite;
							if(j == (filas + auxY) - 1){
								sala[i,j+1] = Instantiate (baldosa, new Vector2 (i,j+1),transform.rotation);
							}


						}else if(j == 0 + auxY){
							baldosa.GetComponent<SpriteRenderer>().sprite = pared.GetComponent<SpriteRenderer>().sprite;

						}else if(i == (columnas + auxX) - 1){
							baldosa.GetComponent<SpriteRenderer>().sprite = pared.GetComponent<SpriteRenderer>().sprite;
							if(j == (filas + auxY) - 1){
								sala[i,j+1] = Instantiate (baldosa, new Vector2 (i,j+1),transform.rotation);
							}

						}else if(j == (filas + auxY) - 1){
							baldosa.GetComponent<SpriteRenderer>().sprite = pared.GetComponent<SpriteRenderer>().sprite;
							sala[i,j+1] = Instantiate (baldosa, new Vector2 (i,j+1),transform.rotation);
							baldosa.GetComponent<SpriteRenderer>().sprite = pared_top.GetComponent<SpriteRenderer>().sprite;
						}
                        if(i == 0 + auxX && j == 0 + auxY)
                        {
                            baldosa.tag = "esquina inferior izquierda";
                        }else if(i == columnas + auxX - 1 && j == 0 + auxY)
                        {
                            baldosa.tag = "esquina inferior derecha";
                        }else if(i == 0 + auxX && j == filas + auxY - 1)
                        {
                            baldosa.tag = "esquina superior izquierda";
                        }else if(i == columnas + auxX - 1 && j == filas + auxY - 1)
                        {
                            baldosa.tag = "esquina superior derecha";
                        }
                        else
                        {
                            baldosa.tag = "muro";
                        }
					

					}else{

						baldosa.GetComponent<SpriteRenderer>().sprite = suelo.GetComponent<SpriteRenderer>().sprite;
						baldosa.tag ="suelo" + tag;
                        baldosa.layer = 9;
						baldosa.GetComponent<BoxCollider2D>().isTrigger = true;

					}
					sala[i,j] = Instantiate (baldosa, new Vector2 (i,j),transform.rotation);

				}
				

			}
			if(salas == salamedio){
				Instantiate(jugador,new Vector3(auxX + columnas / 2,auxY + filas / 2, -1),transform.rotation);
				Instantiate(camara,new Vector3(auxX + columnas / 2,auxY + filas / 2, -10),transform.rotation);
				GenerarSalaInicial(columnas, filas, auxX , auxY);
				
			}
			ponercolumnas(columnas,filas);
			posicion = Random.Range(0,2);
			if(posicion == 0){
				auxX += columnas + 5;
			} else if(posicion == 1){
				auxY += filas + 5 + 1;
			}
			
	    }
		int x=0;
		int y=0;
		int aux = 0;
		for(int contador = 0;aux < Nsalas ; contador ++){
			if(sala[contador + x ,y] == false && sala[contador + x + 5, y] == true){
				posicionamiento(contador + x,y,'h',contpuentes);
				contpuentes++;
				x += contador + 5;
				Nsalas++;
				contador = 0;


			}else if(sala[x,contador + y] == false && sala[x, contador + y + 5] == true){
				posicionamiento(x,contador + y,'v',contpuentes);
				contpuentes++;
				y += contador + 5;
				Nsalas++;
				contador = 0;
			}
		}
		
	}

   
    // Update is called once per frame
    void Update () {
		
		
		
		
		
		
	}
	void puente(int x,int y, char p, int contpuentes){
		
		if(p == 'h'){
			Destroy(sala[-1 + x, y]);
			Destroy(sala[-1 + x, y + 1]);
			Destroy(sala[-1 + x, y + 2]);
			Destroy(sala[-1 + x, y + 3]);
			Destroy(sala[5 + x, y]);
			Destroy(sala[5 + x, y + 1]);
			Destroy(sala[5 + x, y + 2]);
			Destroy(sala[5 + x, y + 3]);
			baldosa.GetComponent<SpriteRenderer>().sprite = pared.GetComponent<SpriteRenderer>().sprite;
			baldosa.tag ="muro";
			baldosa.GetComponent<BoxCollider2D>().isTrigger = false;
			for(int i = 0 + x; i < 5 + x; i++){
				sala[i,y + 4] = Instantiate (baldosa, new Vector2 (i,y + 4),transform.rotation);

			}
			for(int i = -1 + x; i < 6 + x; i++){
				for(int j = 0 + y; j < 4 + y ; j++){
					if(j == 0 + y){

							
							baldosa.GetComponent<SpriteRenderer>().sprite = pared.GetComponent<SpriteRenderer>().sprite;
							baldosa.tag ="muro";
							baldosa.GetComponent<BoxCollider2D>().isTrigger = false;
						

					}else if(j == (3 + y)){
						baldosa.GetComponent<SpriteRenderer>().sprite = pared_top.GetComponent<SpriteRenderer>().sprite;
						baldosa.tag ="muro";
						baldosa.GetComponent<BoxCollider2D>().isTrigger = false;

					}
					else{

							baldosa.GetComponent<SpriteRenderer>().sprite = suelo.GetComponent<SpriteRenderer>().sprite;
							baldosa.tag ="suelo puente";
							baldosa.GetComponent<BoxCollider2D>().isTrigger = true;

					}
						sala[i,j] = Instantiate (baldosa, new Vector2 (i,j),transform.rotation);
						
				}
			}
			puertas[contpuentes] = Instantiate (puertaV,new Vector2(x,y+1.5f),transform.rotation);

		}else if(p == 'v'){
			baldosa.GetComponent<SpriteRenderer>().sprite = suelo.GetComponent<SpriteRenderer>().sprite;
			baldosa.tag ="suelo puente";
			baldosa.GetComponent<BoxCollider2D>().isTrigger = true;
			Destroy(sala[x, y - 1]);
			Destroy(sala[x + 1, y - 1]);
			Destroy(sala[x + 2, y - 1]);
			Destroy(sala[x + 3, y - 1]);
			Destroy(sala[x + 1, y - 2]); sala[x + 1, y - 2]= Instantiate (baldosa, new Vector2 (x + 1, y -2),transform.rotation);
			Destroy(sala[x + 2, y - 2]); sala[x + 2, y - 2]= Instantiate (baldosa, new Vector2 (x + 2, y -2),transform.rotation);
			Destroy(sala[x, y + 5]);
			Destroy(sala[x + 1, y + 5]);
			Destroy(sala[x + 2, y + 5]);
			Destroy(sala[x + 3, y + 5]);
			for(int i = 0 + x; i < 4 + x; i++){
				for(int j = -1 + y; j < 6 + y; j++){
					if(i == 0 + x || i == (3 + x)){

							
							baldosa.GetComponent<SpriteRenderer>().sprite = pared.GetComponent<SpriteRenderer>().sprite;
							baldosa.tag ="muro";
							baldosa.GetComponent<BoxCollider2D>().isTrigger = false;
						

					}else{

							baldosa.GetComponent<SpriteRenderer>().sprite = suelo.GetComponent<SpriteRenderer>().sprite;
							baldosa.tag ="suelo puente";
							baldosa.GetComponent<BoxCollider2D>().isTrigger = true;

					}
						sala[i,j] = Instantiate (baldosa, new Vector2 (i,j),transform.rotation);
						
				}
				puertas[contpuentes] = Instantiate (puertaH,new Vector2(x+1.5f,y),transform.rotation);
			}

		}
		

	}

	void posicionamiento(int x,int y,char p, int contpuentes){
		int contador1 = 0;
		int contador2 = 0;
		if(p == 'h'){

			for(; sala[x - 1, contador1 + y] == true; contador1++);
			for(; sala[x + 5, contador2 + y] == true; contador2++);
			Debug.Log("contador1h: " + contador1);
			Debug.Log("contador2h: " + contador2);
			if(contador1 > contador2){
				puente(x, y + (contador2/2) - 2, p, contpuentes);

			}else{
				puente(x, y + (contador1/2) - 2, p,contpuentes);
			}
	
		}else if(p == 'v'){
			
			for(; sala[contador1 + x, y - 1] == true; contador1++);
			for(; sala[contador2 + x, y + 5] == true; contador2++);
			Debug.Log("contador1v: " + contador1);
			Debug.Log("contador2v: " + contador2);
			if(contador1 > contador2){
				puente(x + (contador2/2) - 2, y, p,contpuentes);

			}else{

				puente(x + (contador1/2) - 2, y, p,contpuentes);

			}


		}
		
		

	}

	void ponercolumnas(int columnas, int filas){
		baldosa.tag= "columna";
		int x = auxX, y = auxY;
		int caso = 0;
		caso = Random.Range(1,5);

		if(filas >= 30 && columnas >=30){
			switch (caso){
				case 1:
					formcolum1();
				break;
				case 2:
					formcolum2();
				break;
				case 3:
					formcolum3();
				break;
				case 4:
					formcolum4();
				break;

			}
			
			
			
		}
		
		else if(filas >= 20 && columnas >= 20){
			switch(caso){
				case 1:
					formcolum4();
				break;
				case 2:
					formcolum5();
				break;
				case 3:
					formcolum6();
				break;

			}
			
					

		} 
		else if(filas >= 10 && columnas >=10){
			switch(caso){
				case 1:
				formcolum7();
				break;
			}

		}
		else if(filas >= 1 && columnas >=1){

		}
		else if(filas > 2 * columnas){

		}
		else if(filas * 2 < columnas){

		}
		else{

		}

	}

	void generacolumna(int x,int y, int dimensionx, int dimensiony = 0){
		int auxX = x;
		int auxY = y;
		baldosa.tag = "columna";
		if(dimensiony == 0){dimensiony = dimensionx;}
		for(;x < dimensionx + auxX; x++){
			baldosa.tag = "columna";
			y = auxY;
			baldosa.GetComponent<BoxCollider2D>().isTrigger = false;
			for(;y < dimensiony + auxY; y++){
				Debug.Log("x de columnas es" + x);
				Destroy(sala[x,y]); 
				if(y == auxY){
					baldosa.GetComponent<SpriteRenderer>().sprite = pared_top.GetComponent<SpriteRenderer>().sprite;
					sala[x,y] = Instantiate (baldosa, new Vector2 (x,y),transform.rotation);

				}else{
					baldosa.GetComponent<SpriteRenderer>().sprite = columna.GetComponent<SpriteRenderer>().sprite;
					sala[x,y] = Instantiate (baldosa, new Vector3 (x,y,-2),transform.rotation);
				}
			}
			if(sala[x,y].GetComponent<BoxCollider2D>().isTrigger == false){
				baldosa.tag = "columna";
				baldosa.GetComponent<BoxCollider2D>().isTrigger = false;

			}else{
				baldosa.tag = "columna_top";
				baldosa.GetComponent<BoxCollider2D>().isTrigger = true;
				
			}
			Destroy(sala[x,y]);
			baldosa.GetComponent<SpriteRenderer>().sprite = columna.GetComponent<SpriteRenderer>().sprite;
			sala[x,y] = Instantiate (baldosa, new Vector3 (x,y,-2),transform.rotation);
		}
	}
	void formcolum1(){
		int dimensionx = 2;
		int ncolumnas = (filas-4)/(2 + 2);
		int x = auxX + 3;
		int y = auxY + 3;			
		for(int contador = 0; contador < ncolumnas; contador++){
			generacolumna(x,y,dimensionx);
			y = y + dimensionx + 2;
		}
		x = auxX + columnas - 3 - dimensionx;
		y = auxY + 3;
		for(int contador = 0; contador < ncolumnas; contador++){
			generacolumna(x,y,dimensionx);
			y = y + dimensionx + 2;
		}

	}
	void formcolum2(){
		int dimensionx = columnas - 6;
		int dimensiony = Random.Range(1,5);
		int ncolumnas = (filas-4)/(dimensiony + 2);
		int x = auxX + 3;
		int y = auxY + 3;
		int caso2 = Random.Range(1,3);
		for(int contador = 0; contador < ncolumnas; contador++){
			if(caso2 == 1 && contador % 2 == 0){
				generacolumna(x,y,dimensionx,dimensiony);
			}else if(caso2 == 2 && contador % 2 != 0){
				generacolumna(x,y,dimensionx,dimensiony);
			}
			y = y + dimensiony + 2;
		}

	}
	void formcolum3(){
		int dimensionx = (columnas - 8) / 2;
	    int dimensiony = Random.Range(1,5);
		int ncolumnas = (filas-4)/(dimensiony + 2);
		int x = auxX + 3;
		int y = auxY + 3;
		int caso2 = Random.Range(1,3);
		for(int contador = 0; contador < ncolumnas; contador++){
			for(int aux = 0;aux < 2; aux ++){
				if(caso2 == 1 && contador % 2 == 0){
					generacolumna(x,y,dimensionx,dimensiony);
				}else if(caso2 == 2 && contador % 2 != 0){
					generacolumna(x,y,dimensionx,dimensiony);
				}
				x = x + dimensionx + 2; 
			}
		    x = auxX + 3;
		    y = y + dimensiony + 2;
		}

	}
	void formcolum4(){
		int dimensionx = 6;
		int dimensiony = 3;
		int x = auxX + 4;
		int y = auxY + filas - 4 - dimensiony;
		generacolumna(x,y,dimensionx,dimensiony);

		dimensionx = 3;
	    x = auxX + 4;
		y = auxY + 4 + dimensiony;
		generacolumna(x,y,dimensionx,dimensiony);
		
		x = auxX + columnas - 4 - dimensionx;
		y = auxY + 4 + dimensiony;
		generacolumna(x,y,dimensionx,dimensiony);

		dimensionx = 6;
		x = auxX + 4;
		y = auxY + 4;
		generacolumna(x,y,dimensionx,dimensiony);

		x = auxX + columnas - 4 - dimensionx;
		y = auxY + filas - 4 - dimensiony;
		generacolumna(x,y,dimensionx,dimensiony);

		x = auxX + columnas - 4 - dimensionx;
		y = auxY + 4;
		generacolumna(x,y,dimensionx,dimensiony);

		x = auxX + 4;
		y = auxY + filas - 4 - dimensiony*2;
		dimensionx = 3;
		generacolumna(x,y,dimensionx,dimensiony);

		x = auxX + columnas - 4 - dimensionx;
		y = auxY + filas - 4 - dimensiony * 2;
		generacolumna(x,y,dimensionx,dimensiony);

	}
	void formcolum5(){
		int dimensionx = 4;
		int x = auxX + 4;
		int y = auxY + filas - 4 - dimensionx;
		generacolumna(x,y,dimensionx);

		x = auxX + 4;
		y = auxY + 4;
		generacolumna(x,y,dimensionx);

		x = auxX + columnas - 4 - dimensionx;
		y = auxY + filas - 4 - dimensionx;
		generacolumna(x,y,dimensionx);

		x = auxX + columnas - 4 - dimensionx;
		y = auxY +  4;
		generacolumna(x,y,dimensionx);
	}
	void formcolum6(){
		int dimensionx = 2;
		int dimensiony = 2;
		int x = auxX + 2;
		int y = auxY + 3;
		int nx = 0, ny = 0;
		int ncolumnas = (filas-4)/(dimensionx + 2);
		for(int contador = 0; contador < ncolumnas; contador ++){
			for(int contador2 = 0; contador2 < (columnas-4)/(dimensionx+2);contador2 ++ ){
				generacolumna(auxX + 3,y,dimensionx,dimensiony);
				x = auxX + 2 + nx;
				y = auxY + 3 + ny;
				nx= nx + 2 + dimensionx;
			}
			ny = ny + 2 + dimensionx;
			nx = 0;
		}
	}
	void formcolum7(){
		int dimensionx = 0;
		if(filas < columnas){
		    dimensionx = Random.Range(4,filas - 4) ;

		}else{
			dimensionx = Random.Range(4,columnas - 4) ;

		}
					
		int x = (auxX + columnas/2) - (dimensionx/2);
		int y= (auxY + filas/2) - (dimensionx/2);
					
		generacolumna(x,y,dimensionx);
	}
	void GenerarSalaInicial(int columnas, int filas, int x, int y){
		int auxX;
		int auxY;
		baldosa.tag = "salaini";
		if(sala[x + columnas/2, y - 6] == true){
			y = (int)(y + filas/2);
			x = x - 12;
			auxX = x;
			auxY = y;
			
		}else{
			x = (int)(x + columnas/2) - 3;
			y = y - 12;
			auxX = x;
			auxY = y;

			
		}
		for(x = auxX; x < (auxX + 6); x++){
				for(y = auxY; y < (auxY + 6); y++){
					if(x == auxX || x == auxX + 5 || y == auxY || y == auxY + 5){
						baldosa.layer = 8;
						baldosa.GetComponent<BoxCollider2D>().isTrigger = false;
						if(y == auxY + 5 && x != auxX && x != (auxX + 5)){
							baldosa.GetComponent<SpriteRenderer>().sprite = pared_top.GetComponent<SpriteRenderer>().sprite;
						}else{
							baldosa.GetComponent<SpriteRenderer>().sprite = pared.GetComponent<SpriteRenderer>().sprite;

						}
						
						
					
					}else {
						baldosa.layer = 9;
						baldosa.GetComponent<BoxCollider2D>().isTrigger = true;
						baldosa.GetComponent<SpriteRenderer>().sprite = suelo.GetComponent<SpriteRenderer>().sprite;

					}
					sala[x,y] = Instantiate (baldosa, new Vector2 (x,y),transform.rotation);
					y = auxY + 6;
					baldosa.GetComponent<BoxCollider2D>().isTrigger = false;
					baldosa.GetComponent<SpriteRenderer>().sprite = pared.GetComponent<SpriteRenderer>().sprite;
					for(x = auxX;x < (auxX + 6); x++){
						sala[x,y] = Instantiate (baldosa, new Vector2 (x,y),transform.rotation);

					}
				}
			
			}

		
		

	}

}
