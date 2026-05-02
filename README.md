# 🎬 Anime Watchlist - Proyecto MVC

## 📌 Justificación y Motivación

He elegido este proyecto porque me apasiona el anime y quería crear una aplicación original que consumiera una API pública. En clase muchos compañeros hicieron proyectos sobre películas, así que decidí hacer algo diferente y enfocado en el mundo del anime.

Esta aplicación permite a los usuarios:
- Explorar los 25 animes más populares
- Buscar cualquier anime por nombre
- Ver detalles completos (valoración, episodios, sinopsis)
- Guardar sus animes favoritos en una lista personal

## 🏗️ Esquema de Arquitectura
┌─────────────────────────────────────────────────────────────┐
│ NAVEGADOR │
└─────────────────────────────────────────────────────────────┘
↓
┌─────────────────────────────────────────────────────────────┐
│ CONTROLADOR │
│ (AnimeController.cs) │
│ - Index(): Muestra lista de animes │
│ - Details(id): Muestra detalles de un anime │
│ - Watchlist(): Muestra lista guardada │
└─────────────────────────────────────────────────────────────┘
↓ ↓
┌──────────────────────────────┐ ┌────────────────────────────┐
│ MODELO │ │ VISTAS │
│ (Anime.cs) │ │ (Index.cshtml) │
│ - Id │ │ (Details.cshtml) │
│ - Title │ │ (Watchlist.cshtml) │
│ - Rating │ │ │
│ - Description │ │ Lenguajes: │
│ - Episodes │ │ - HTML │
│ - Images │ │ - CSS │
└──────────────────────────────┘ │ - JavaScript │
↓ │ - Razor (@) │
┌──────────────────────────────┐ └────────────────────────────┘
│ API EXTERNA │
│ (Jikan API) │
│ - myanimelist.net data │
└──────────────────────────────┘

text

## 📝 Explicación Detallada del Código (MVC)

### Modelo (Anime.cs)
Define la estructura de los datos que recibimos de la API. Cada anime tiene:
- `Id`: Identificador único (int)
- `Title`: Título del anime (string)
- `Rating`: Puntuación de 0-10 (double?)
- `Description`: Sinopsis (string)
- `Episodes`: Número de episodios (int?)
- `Images`: URL de la imagen (objeto anidado)

El uso de `double?` y `int?` permite valores nulos para animes sin datos.

### Controlador (AnimeController.cs)
Gestiona las peticiones del usuario:

**Método Index()** - Página principal
```csharp
public async Task<IActionResult> Index(int page = 1, string search = null)
Recibe página y término de búsqueda

Construye URL de API con parámetros limit=25 y page

Si hay búsqueda, usa ?q=

Deserializa JSON a objetos C#

Envía lista a la vista

Método Details() - Página de detalles

csharp
public async Task<IActionResult> Details(int id)
Recibe ID del anime

Llama a API específica: /anime/{id}

Devuelve un solo objeto a Details.cshtml

Método Watchlist() - Lista personal

csharp
public IActionResult Watchlist()
Solo devuelve la vista

Los datos vienen de localStorage (navegador)

Vistas (Archivos .cshtml)
Index.cshtml

Muestra grid de 25 animes

Contiene barra de búsqueda

Botones de paginación

JavaScript para guardar en localStorage

Details.cshtml

Muestra imagen grande

Sinopsis completa

Botón para añadir a watchlist

Watchlist.cshtml

Lee de localStorage

Muestra animes guardados

Permite eliminar

Almacenamiento Local (localStorage)
javascript
// Guardar
localStorage.setItem('animeWatchlist', JSON.stringify(watchlist));

// Leer
let watchlist = JSON.parse(localStorage.getItem('animeWatchlist'));

// Eliminar
localStorage.removeItem('animeWatchlist');
🚀 Propuestas de Mejora
YouTube Trailers: Integrar vídeos de anime usando YouTube API

Personajes: Mostrar personajes principales usando Character API

Modo Oscuro/Claro: Alternar entre temas

Filtros por género: Permitir filtrar por tipo de anime

Compartir lista: Exportar watchlist a JSON

Recomendaciones: Sugerir animes similares

Cuentas de usuario: Sincronizar watchlist entre dispositivos

🛠️ Tecnologías Utilizadas
Tecnología	Uso
C#	Lógica del servidor
.NET Core 8	Framework web
MVC	Patrón arquitectónico
Razor	Plantillas HTML
Newtonsoft.Json	Serialización JSON
Jikan API	Datos de anime
localStorage	Almacenamiento cliente
📦 Instalación y Ejecución
bash
git clone <tu-repositorio>
cd AnimeProject
dotnet restore
dotnet run
Abrir navegador: http://localhost:5000/Anime

👤 Autor
chorouq
chorouq.lagmani@estudiant.fjaverianas.com
GitHub:chorouqla

📅 Fecha
Mayo 2026
