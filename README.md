Simulador de Decisiones para Plataforma de Streaming

Este es un proyecto académico desarrollado para el curso de Pensamiento Computacional de la Facultad de Ingeniería. Su objetivo principal es simular una consola de decisiones para el equipo de una plataforma de streaming. El programa no almacena bases de datos de películas, sino que funciona como un filtro en tiempo real que evalúa las solicitudes de contenido una por una para decidir si pueden ser publicadas esta semana, aplicando reglas de negocio específicas.

 Descripción del sistema
El sistema es una aplicación de consola desarrollada en C# que evalúa contenidos (Películas, Series, Documentales o Transmisiones en vivo) basándose en varios criterios técnicos:
* **Duración:** Se verifica que el contenido esté dentro del rango de minutos permitido para su tipo.
* **Clasificación y Horario:** Se valida que el horario de transmisión programado sea adecuado para la edad recomendada (Todo público, +13 o +18).
* **Nivel de Producción:** Se comprueba que la calidad de producción sea apta para el público objetivo.

Una vez validado técnicamente, el sistema clasifica el impacto del contenido (Alto, Medio o Bajo) y emite una decisión final:
1. Publicar: Cumple reglas e impacto bajo.
2. Publicar con ajustes: Cumple reglas e impacto medio.
3. Enviar a revisión: Cumple reglas pero tiene un impacto alto.
4. Rechazar: Incumple alguna de las reglas técnicas obligatorias.

El programa mantiene y muestra estadísticas en tiempo real durante la sesión de evaluación.

## Instrucciones para ejecutarlo
Para correr este programa en tu computadora, necesitas tener instalado el SDK de .NET o un entorno de desarrollo como Visual Studio.

1. Clona o descarga este repositorio en tu computadora.
2. Abre el archivo de la solución (`.sln`) con Visual Studio.
3. Presiona el botón de **Iniciar** (o la tecla `F5`) para compilar y ejecutar el programa en la consola.

