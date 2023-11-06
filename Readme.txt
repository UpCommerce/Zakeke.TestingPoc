Salve,

Hai appena aperto la Proof of Concept (POC) di Zakeke dedicata al testing.

Questo progetto contiene gli elementi fondamentali per configurare il testing automatico di un'applicazione.

All'interno di Zakeke.Testing troverai i test propriamente detti, mentre Calculator contiene una Console Application strutturata attorno a una classe statica (Operations) e una classe non statica (ConsoleMask).

La classe Operations verrà utilizzata per approfondire il testing dei componenti, mentre ConsoleMask serve come esempio di Dependency Injection.

I test di integrazione si distinguono dai test unitari poiché richiedono l'integrazione di dipendenze esterne per funzionare.

Un test si considera di integrazione quando necessita dell'integrazione di dipendenze o applicativi differenti.

Per semplicità, in questa POC non verranno effettuate vere e proprie chiamate a sistemi esterni.

Nei nostri test di integrazione, ci limiteremo a iniettare le dipendenze. 
Per fare ciò, necessitiamo di un ambiente di test, che è il fulcro della Dependency Injection, in quanto consente di collegare al test un container per la Dependency Injection.

L'ambiente di test, denominato ConsoleMaskTestBed, è responsabile di registrare e configurare le dipendenze, oltre a gestirne il ciclo di vita. In questo contesto, "decide" quali dipendenze saranno accessibili al provider di Dependency Injection durante l'esecuzione del test.

L'ambiente di test gestisce le dipendenze secondo le seguenti fasi:

a) Inizializzazione: si invoca il costruttore e, immediatamente dopo, il metodo InitializeAsync. 

Questa fase è solitamente dedicata alla configurazione dell'ambiente di test, al login o alla preparazione dei dati necessari.

b) Registrazione e configurazione dei servizi:

- GetTestAppSettings (recupera il file appsettings.test.json)
- AddServices (registra le dipendenze necessarie per il test)

c) Costruzione dell'ambiente di test e preparazione delle dipendenze.

d) In conclusione, si procede con la distruzione dell'ambiente di test, invocando i metodi Dispose previsti da IAsyncLifetime.

Esiste una ridondanza nei metodi di dispose: uno derivante dall'implementazione di IAsyncLifetime e l'altro dall'override nella classe astratta TestBedFixture. Non è strettamente necessario modificare entrambi i metodi. Per convenzione, si raccomanda di non modificare il metodo DisposeAsyncCore di TestBedFixture e di gestire tutte le operazioni di chiusura nel metodo DisposeAsync di IAsyncLifetime.

I test sono idempotenti, una caratteristica importante che consente di ripeterli più volte senza il rischio di alterare l'ambiente di test reale.

I test di integrazione sono organizzati nella cartella "Integration", mentre i test unitari si trovano nella cartella "Component".