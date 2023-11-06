Salve a te,

hai appena aperto la Proof of Concept (POC da adesso in poi) del testing di Zakeke.

Questo progetto contiene gli elementi essenziali per allestire il testing automatico di un applicativo.

Dentro Zakeke.Testing trovi i test veri e propri, mentre Calculator contiene una Console Application il cui scheletro è
dato da una classe statica (Operations) e una classe non statica (ConsoleMask)

La classe Operations sarà usata per esplorare il component testing, UserMask invece è utilizzata per un esempio di Dependency Injection.

I test di integrazione si differenziano dai test unitari perché, per funzionare,  necessitano di integrare tra loro dipendenze esterne. 

Un test è di integrazione quando per il suo funzionamento necessita di integrare dipendenze o applicativi diversi.

Per semplicità, in questa POC non saranno veramente chiamati sistemi esterni.

Nel nostro caso di integration test, ci limiteremo quindi a iniettare le dipendenze, per fare questo avremo
bisogno di un letto di test.
Il letto di test è l'elemento cardine della Dependency Injection, in quanto permette di allacciare al test un container di Dependency Injection.

Il letto di test è responsabile di registrare le dipendenze , configurarle, e gestirne il ciclo di vita , in tal senso, "decide"  quali
dipendenze saranno accessibili al Dependency Injection provider nel test vero e proprio.

Il letto di test si chiama ConsoleMaskTestBed, e le dipendenze hanno questo ciclo di vita:

a) Inizializzazione: viene chiamato il costruttore, subito dopo, viene immediatamente chiamato il metodo "InitializeAsync".

Tipicamente, in questa fase si configura l'ambiente di test, possono essere fatte delle login, oppure possono essere preparati i dati di test.

b) Vengono chiamati i metodi di registrazione dei servizi e di configurazione, ovvero:
	a1) GetTestAppSettings (recupera il file appsettings.test.json)
	a2) AddServices (registra le dipendenze di test)

c) Viene Costruito il test e vengono predisposte le dipendenze

d) A conclusione, vengono chiamati i metodi di dispose del letto di test, vengono poi chiamati i metodi di dispose
del metodo IAsyncLifetime

Evidentemente, c'è una ridondanza dei metodi di dispose, uno deriva dall'implementazione di IAsyncLifeTime, l'altro dall'override
della classe astratta TestBedFixture, non è strettamente necessario modificare entrambi i metodi, per convenzione, si suggerisce
di non modificare il metodo di override di TestBedFixture, ovvero DisposeAsyncCore, e di gestire tutte le operazioni di chiusura
nel metodo asincrono DisposeAsync proveniente da IAsyncLifeTime.

I test sono tutti idempotenti, una proprietà importante perché permette di ripetere i test a oltranza senza rischio di alterare l'ambiente di test vero e proprio.

I test di integrazione sono raggruppati dentro la cartella "Integration", mentre i test unitari dentro la cartella "Component"