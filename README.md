# Bankomaten
Programmet är en enkel bankomat med funktioner för att se inprogrammerade användarens konton, samt interaktera med
den inloggade användarens konton.
Den innehåller login funktion, där man loggar in med ett användarnamn och pinkod och en användar meny som innehåller
val av funktioner man kan göra med kontona när man loggat in. Om man skriver fel pinkod 3 gånger stoppar programmet
och man måste starta om det.
I den menyn kan man välja en funktion som skriver ut vilka konton man har samt vad saldot är på de kontona. Det finns
också en funktion att föra över pengar mellan ett av dina konton till ett annat, där används en metod som ser till
att under överförningens gång så sparas penga värderna med bara 2 decimaler. En annan funktion man kan välja är att
ta ut pengar från ett konto. Det sista valet i menyn loggar ut dig från bankomaten och skickar tillbaka dig till
inloggningen igen.

Bra saker att tänka på om man programmerar i programmet:
Index variablen är en statisk variabel som kan kallas när som helst och sätts redan efter ett giltligt användarnamn
har skrivits in och sparats i variabeln user i Main metoden.

Om man lägger till ny användare måste man se till att man ökar storleken på alla arrays så att det inte blir
indexoutofbounds exceptions, då samma index används för alla arrays.

================================================================================================================================================================
# Resonemang

Jag valde att skapa 2 olika arrays för userNames och userPins då jag tyckte det var enkelt att göra så för att få
det att funka. Det var enkelt på grund av hur jag byggde systemet, jag byggde det steg för steg så när jag byggde
användarnamn metoden så skapade jag användarnamn arrayen och sedan när jag gjorde pinkods metoden skapade jag pinkod
arrayen. Detta ledde till att det kändes enklare då att skapa en array var till användarnamn och pinkod. I efterhand
hade det nog varit snyggare och smidigare att göra dom i en 2d array och på så sätt ha en mindre variabel att komma ihåg.
Så om jag skulle uppdatera den delen av systemet är det nog det första jag skulle ändra.

För kontona valde jag att skapa en 2d array för varje användare och sedan samla arrayerna i en jagged array.
Detta för att jag tyckte det var enklast att spara både namnet och saldon på kontot i samma array, och genom att
lägga in arrayerna i en jagged array kan jag enkelt komma åt rätt användares konton. 
Jag ser inte någon ändring jag skulle kunna göra för att göra det smidigare, däremot skulle jag kunna bygga på den
alternativa lösningen för användarnamn och pinkods arrayerna genom att lägga till de i samma jagged array som kontona.

Jag valde att dela upp inloggningen i två metoder, en som hanterar användarnamn och en som hanterar pinkoden.
Detta gjorde jag då jag tyckte det var både enklare att bygga utifrån hur jag byggde systemet, och att det gjorde
att man enkelt kunde förstå vad metoderna gjorde. Jag byggde systemet steg för steg, så jag började med att göra 
användarnamn delen av inloggningen och sedan efter det gjorde jag pinkods delen. Detta ledde till att jag på varje
steg skapade en metod som hanterade det steget. I efterhand skulla jag ha kunnat skapa inloggningen i en och samma
metod men i stunden jag programmerade kändes det enklare att skapa två olika metoder. Kan inte säga om det skulle
vara en bättre lösning än det jag gjorde, men det är en ändring man skulle kunna göra om man tycker det.

Jag valde att skapa en egen metod för menyn som en inloggad användare ser. Detta för att jag ville hålla min main
metod kort och utan stora block av kod. Om jag hade haft menyn i main metoden hade det förmodligen egentligen inte 
ändrat något, men jag tyckte det blev en enklare läst kod att ha den i sin egen metod.

I metoden AccountMoneyTransfer när man ska välja vilket konto man ska överföra från och till, så skrivs de konton
man kan välja ut. Däremot skrivs inte saldona på kontona ut. Detta för att vid stunden då jag skrev den delen av
koden tänkte jag inte på att det skulle kunna vara en bra idé. Så en förbättring jag skulle kunna göra där är att
lägga till så att den också skriver ut saldona.

När det gäller AccountMoneyTransfer valde jag att skapa en ny metod som hade med överföringen av pengar att göra,
istället för att ha den koden i samma metod. Detta för att jag tyckte det blev lättare att läsa koden om den koden
låg i sin egen metod. Man skulle kunna ta ut koden ur SelfMoneyTransfers metoden och lägga in den i AccountMoneyTransfer,
men det skulle egentligen inte ändra någoting och kan göra koden lite svårare att läsa.

Jag har valt att använda Math.Truncate för att se till att man bara hanterade kr och öre och inte
fick för många decimaler. Jag valde att använda det då jag hittade den idén online och tyckte den både passade som
lösning och gillade hur den funkade. Man skulle kunna istället använda Math.Round, men det skulle kunna leda till
att man för 1 mer öre varje gång man överför. Detta därför att det avrundar uppåt om den tredje decimalen är 5 eller högre.

Jag valde att göra UserIndex metoden då jag i tidigare versioner av programmet hade samma funktion ut skriven på
flera olika ställen, då bestämde jag mig för att flytta över den funktionen i sin egen metod och på så sätt minska
rader kod man behövde skriva i resten av programmet. Men inte långt efter det kom jag på att jag kunde ha index
variabeln som en statisk variabel, detta gjorde att jag bara behövde sätta värdet för index variabeln en gång och
ändå kunna använda den i hela programmet. Detta har gjort att UserIndex metoden inte egentligen behöver finnas då
jag bara behöver skriva den kodbiten en gång. Samtidigt så finns det egentligen ingen anledning att ta bort metoden
heller.

Anledningen till att jag valde att skapa Write metoden var för att jag tyckte det blev lite tråkigt att all text var
vit. Då kom jag på idén med att göra den regnbågs färgat, och tyckte det blev fint. Några problem med det är däremot
att det kan ibland vara svårt att se vad som står bara genom att ge en snabb blick. Om jag skulle skapa ett project
som skulle användas av någon annan än jag skulle jag nog inte använda denna metod då det skulle kunna göra det svårt
för användare att använda programmet på ett användarvänligt sätt. Man skulle också kunna ändra vilka färger som används
och hur många bokstäver som skrivs i en viss färg i rad och på så sätt göra det lite enklare att läsa.
