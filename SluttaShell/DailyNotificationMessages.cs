using System.Collections.Generic;

// Gnarly, but converting from previous project, this proved easier
public static class DailyNotificationMessages
{
    public static readonly Dictionary<string, string> DayZeroPopupMessages = new Dictionary<string, string>() {
        { "smoke", "Hei! Det at du har valgt å slutte å røyke vil påvirke kroppen din og livet ditt positivt på flere måter enn du tror. Dette vil du få vite mer om i meldingene du mottar på din mobil fremover. Lykke til! Å slutte å røyke er det viktigste du gjør for helsen din." },
        { "snus", "Hei! Det at du har valgt å slutte å snuse vil påvirke kroppen din og livet ditt positivt på flere måter enn du tror. Dette vil vi fortelle deg litt om i meldingene du mottar på mobilen din i tiden fremover. Lykke til!" },
        { "snusAndSmoke", "Hei! Det at du har valgt å slutte vil påvirke kroppen din og livet ditt positivt på flere måter enn du tror. Dette vil vi fortelle deg litt om i meldingene du mottar på mobilen din i tiden fremover. Lykke til!" }
    };

    public static readonly Dictionary<int, Dictionary<string, string[]>> LocalNotifsSmoke = new Dictionary<int, Dictionary<string, string[]>>()
    {
        {
            -10, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Nå er det ikke lenge til du skal slutte å røyke. Du kan gjøre flere av de samme forberedelsene som en idrettsutøver må gjennom før en konkurranse. En metode som idrettsfolk ofte bruker er såkalt mental trening. Det vil si at de lager seg et indre bilde av konkurransen og ser seg selv som vinneren. Det kan du også prøve for å slutte å røyke."
                    }
                }
            }
        },
        {
            -9, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Lag deg en liste over alt du kommer på som skal til for å slutte å røyke. Ha listen lett tilgjengelig og legg til nye ting etter hvert som du kommer på dem."
                    }
                }
            }
        },
        {
            -8, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Prøv å skrive opp hvor mange sigaretter du røyker hver dag. Senere kan du se om det er enkelte dager du røykte ekstra mye. Prøv å finne ut hvorfor du røykte så mye akkurat disse dagene og vær forberedt hvis det oppstår liknende situasjoner."
                    }
                }
            }
        },
        {
            -7, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Lag deg røykfrie soner og bestem deg for aldri mer å røyke der. Det kan være på vei til skole eller jobb, i bilen eller hjemme hos deg selv."
                    }
                }
            }
        },
        {
            -6, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Prøv å bryte noen koblinger mellom situasjoner og røyking. Det kan være den første røyken om morgenen eller røyken etter middag. Koblingen forsvinner gradvis når du har vært gjennom dem noen ganger uten å røyke."
                    }
                }
            }
        },
        {
            -5, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Prøv å tenke ut noe du liker å drive med og som kan holde deg i aktivitet når du slutter. Det kan forebygge rastløshet."
                    }
                }
            }
        },
        {
            -4, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Noter ned alle de positive sidene ved å slutte å røyke du kan komme på."
                    }
                }
            }
        },
        {
            -3, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Lag en plan for hva du skal gjøre når nikotinsuget melder seg. Tenk gjennom hva du vil gjøre – noe som tar oppmerksomheten din bort fra det."
                    }
                }
            }
        },
        {
            -2, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Informer dine nærmeste om at du skal slutte – og be om støtte."
                    }
                }
            }
        },
        {
            -1, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Fjern askebegre og sigaretter, og gjør hjemmet ditt til en røykfri sone. Se for deg hvordan det er å være røykfri og hva du skal gjøre i situasjoner der du ellers ville tatt en røyk. Nå starter ditt nye, røykfrie liv!"
                    }
                }
            }
        },
        {
            0, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hei! Det at du har valgt å slutte å røyke, vil påvirke kroppen din og livet ditt positivt på flere måter enn du tror. Dette vil du få vite mer om i meldingene du mottar på din mobil fremover. Lykke til! Å slutte å røyke er det viktigste du gjør for helsen din.",
                        "Oksygenopptaket i kroppen din blir bedre jo lenger det er siden siste røyk. Kullos (CO) i blodet reduseres for hver time du ikke røyker. Dette betyr at blodet ditt transporterer mer oksygen rundt i kroppen.",
                    }
                },
                {
                    "Penger", new string[] {
                        "Hei. Du sparer penger for hver røyk eller snus du ikke tar i dag og i tiden framover. Dessuten er det å slutte med tobakk det viktigste du gjør for helsen din."
                    }
                },
                {
                    "Mine nærmeste", new string[] {
                        "Hei. Å slutte å røyke og snuse er det viktigste du gjør for helsen din. Det har stor betydning for dine nærmeste at du har valgt å slutte!"
                    }
                },
                {
                    "Utseende", new string[] {
                        "Hei. Å slutte med tobakk er det viktigste du gjør for helsen din. Og du bremser også aldringsprosessen!"
                    }
                }
            }
        },
        {
            1, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hodepine er en vanlig plage i forbindelse med røykeslutt. Dette kan skyldes økt stress og forbigående svingninger av blodsukkeret og blodtrykket. Trening, vann og avslapning kan hjelpe.",
                        "Rastløshet, irritasjon og uro er vanlige plager når man slutter å røyke. Det kan føles tungt, men det går over! Det hjelper å drikke nok væske og være aktiv.",
                        "Hei! Nivået av kullos (CO) og oksygen i blodet er normalisert. Risikoen for hjerteinfarkt reduseres etter 24 timer.",
                        "Gratulerer! Du har vært røykfri i 24 timer."
                    }
                }
            }
        },
        {
            2, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Røykånden din skal nå være helt borte.",
                        "Svette er et vanlig abstinenssymptom. Kroppen din renser ut giftstoffer. Drikk mye vann!",
                        "Hei! Smaks- og luktesansen din bedres, og blodsirkulasjonen til hendene er allerede bedre.",
                        "Gratulerer! Du har vært røykfri i 48 timer."
                    }
                },
                {
                    "Mine nærmeste", new string[] {
                        "Hei. Ved å slutte med tobakk beskytter du de du er mest glad i. Vær forberedt på at kroppen din nå jobber med å bli kvitt avhengigheten og du kan svette mer enn vanlig. Husk å drikke mye vann."
                    }
                },
                {
                    "Utseende", new string[] {
                        "Hei. Nå slipper du å bekymre deg for flere og dypere rynker. Vær forberedt på at kroppen din jobber med å bli kvitt avhengigheten og du kan svette mer enn vanlig. Husk å drikke mye vann."
                    }
                }
            }
        },
        {
            3, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Du kan oppleve at du tåler mindre kaffe og cola når du slutter å røyke fordi koffeinet forbrennes saktere. For mye koffein kan forveksles med abstinensplager.",
                        "Den fysiske nikotinavhengigheten er verst de første dagene. Fortsett å holde ut, du er snart over det.",
                        "Hei! Lungekapasiteten øker, og bedre blodgjennomstrømning i huden gjør at du får friskere ansiktsfarge.",
                        "Gratulerer! Du har vært røykfri i 72 timer."
                    }
                },
                {
                    "Penger", new string[] {
                        "Abstinensplagene er verst de første dagene, fortsett å holde ut, du er snart over det. Og gled deg over pengene du sparer!"
                    }
                },
                {
                    "Mine nærmeste", new string[] {
                        "Den fysiske avhengigheten er verst de første dagene, fortsett å holde ut, du er snart over det."
                    }
                },
                {
                    "Utseende", new string[] {
                        "Blodsirkulasjonen blir bedre raskt etter at du slutter. Selv om du ikke har merket det enda er dette bra for både hud og hår. Den fysiske avhengigheten er verst de første dagene, fortsett å holde ut, du er snart over det."
                    }
                }
            }
        },
        {
            4, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Lungene dine trives som røykfrie og de har det bedre enn på lenge.",
                        "Dersom du trener, får du nå bedre utbytte av treningen.",
                        "Hei! Husk at du sparer penger for hver røyk du ikke tar. Et godt råd er å legge pengene til side slik at du ser hvor mye du sparer."
                    }
                },
                {
                    "Penger", new string[] {
                        "Det å slutte er godt for både kroppen og lommeboka. Dersom du trener, får du nå bedre utbytte av treningen."
                    }
                },
                {
                    "Mine nærmeste", new string[] {
                        "Din beslutning om å slutte har positive helseeffekter for dem rundt deg. Og dersom du trener, får du nå bedre utbytte av treningen."
                    }
                },
                {
                    "Utseende", new string[] {
                        "Dersom du trener, får du nå bedre utbytte av treningen. Trening stimulerer også blodomløpet slik at det blir lettere for hud og hår å utnytte næringen du har fått i deg."
                    }
                }
            }
        },
        {
            5, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Si til deg selv: N.O.P.E (Not One Puff Ever!). Si det høyt og med stolthet! Å ta ett trekk fører lett til ett til og ett til og ett til …",
                        "Når du slutter å røyke svinger blodsukkeret mer. Regelmessige, små måltider hjelper deg å holde blodsukkeret i sjakk.",
                        "Hei! Kommer du til å bli fristet hvis andre rundt deg tar en røyk? Det kan være lurt å forberede deg før du står midt i situasjonen. Hva skal du si hvis noen tilbyr deg røyk?"
                    }
                }
            }
        },
        {
            6, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Abstinenser kommer av at hjernen ikke tilføres nikotin fra røyken. Hold ut, det går over!",
                        "Røyksug kan forveksles med sultfølelse. Finn ut om du er sulten eller røyksugen, og gjør nødvendige tiltak! Spis litt eller få oppmerksomheten over på noe annet.",
                        "Hei! Som ikke-røyker har du mindre risiko for luftveisinfeksjoner."
                    }
                },
                {
                    "Penger", new string[] {
                        "Tenk på hvordan du vil bruke pengene du sparer. Nikotinsug kan forveksles med sultfølelse. Finn ut om du er sulten eller nikotinsugen, og gjør nødvendige tiltak. Spis litt eller få oppmerksomheten over på noe helt annet."
                    }
                },
                {
                    "Mine nærmeste", new string[] {
                        "Å slutte med tobakk øker sjansen for unngå alvorlig sykdom. Som igjen gir muligheten for flere bursdager, bryllupsdager eller cupfinaler sammen med dem du er glad i. Nikotinsug kan forveksles med sultfølelse. Finn ut om du er sulten eller nikotinsugen, og gjør nødvendige tiltak. Spis litt eller få oppmerksomheten over på noe helt annet. "
                    }
                },
                {
                    "Utseende", new string[] {
                        "Som tobakksfri har du bedre blodgjennomstrømning, og alle sår gror bedre. Husk at dette er en forutsetning for å unngå stygge arrdannelser og for igangsettelse av flere typer operasjoner. Nikotinsug kan forveksles med sultfølelse. Finn ut om du er sulten eller nikotinsugen, og gjør nødvendige tiltak. Spis litt eller få oppmerksomheten over på noe helt annet."
                    }
                }
            }
        },
        {
            7, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "De fleste som røyker begynte sammen med venner eller kjæresten. Tenk gjennom hva du skal svare hvis de spør om du vil ha.",
                        "Etter en uke er det mange som synes det går litt lettere. Hvis du sliter, snakk med en venn eller kollega. Støtte fra andre motiverer!",
                        "Gratulerer med en uke som røykfri! For noen hjelper det å fortelle andre om sitt slutteprosjekt. Støtte fra andre kan gjøre det lettere å holde seg røykfri.",
                        "Gratulerer! Du har vært røykfri i en uke."
                    }
                }
            }
        },
        {
            8, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Kroppen opplever stress og nervesystemet ditt omstiller seg. Dersom det er vanskelig å sove, vær forsiktig med koffein på kveldstid og gå en kort tur før du legger deg.",
                        "Hosting og kribling i halsen kan komme av at flimmerhårene våkner til liv igjen.",
                        "Hei! Du er et godt forbilde for andre som tobakksfri."
                    }
                }
            }
        },
        {
            9, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Har du lagt merke til at du ikke lenger trenger å stresse med planlegging av når og hvor du kan ta neste røyk? Godt å slippe det!",
                        "Å drikke alkohol vil gi deg lavere impulskontroll, noe som kan gjøre det vanskeligere å la være å røyke.",
                        "Hei! Selv om du enda ikke merker noe til det, så har kroppen din det mye bedre."
                    }
                }
            }
        },
        {
            10, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Lurer du på noe om røyking og helseskader, se slutta.no. Snakk med legen din om du har spørsmål om egen helse.",
                        "Om du trenger mer hjelp underveis, så finnes det en chatbot du kan teste ut på Messenger. Søk etter Slutta – din røykeslutt. Den vil vises under \"Bedrifter\" i søkeresultatet. Trykk på \"kom i gang\" og følg instruksjonene.",
                        "Hei! Minn deg selv på at hver gang du motstår suget, øker din kontroll over røyken."
                    }
                }
            }
        },
        {
            11, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Røykeslutt gir deg bedre ånde.",
                        "Du får bedre effekt av treningen din som røykfri.",
                        "Hei! Fysisk aktivitet hjelper mot stress og er en god distraksjon fra røyksug."
                    }
                }
            }
        },
        {
            12, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Klærne dine og håret ditt lukter ikke røyk lenger. Håper det gir deg en god følelse.",
                        "Ikke glem å minne deg selv på grunnene dine for å slutte. Det gjør deg motivert!",
                        "Hei! Snart to uker uten røyk. Begynn planlegging av en liten belønning! Fordi du fortjener det!"
                    }
                }
            }
        },
        {
            13, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Vær litt fysisk aktiv i dag - det hjelper! Husk å drikke vann og fruktjuice!",
                        "Hei! Får du mer lyst på noe søtt å spise nå som du har sluttet? Ha tilgjengelig noe enkelt - som frukt, grønnsaker eller nøtter!"
                    }
                }
            }
        },
        {
            14, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Du har kommet langt og nå gjelder det å ikke gi seg.",
                        "Gratulerer! Du er halvveis til «magiske» 28 røykfrie dager. Forskning viser nemlig at 28 røykfrie dager femdobler sjansen for å slutte for godt! Det er nesten magi!"
                    }
                },
                {
                    "Penger", new string[] {
                        "Når du slutter har du mer romslig økonomi. Det betyr litt mer hverdagsluksus, flere ferier, aktiviteter med familien og gaver til personer du er glad i."
                    }
                },
                {
                    "Mine nærmeste", new string[] {
                        "Når du slutter har du mer romslig økonomi. Det betyr litt mer hverdagsluksus, flere ferier, aktiviteter med familien og gaver til personer du er glad i."
                    }
                },
                {
                    "Utseende", new string[] {
                        "Røykeslutt er bra for tennene. Røyking svekker forsvaret mot bakteriebelegg og gir økt risiko for tannkjøttbetennelsen periodontitt. I verste fall kan det føre til at tennene løsner."
                    }
                }
            }
        },
        {
            15, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Røykeslutt gjør at du får bedre blodsirkulasjon i hele kroppen. Kanskje fryser du mindre på beina allerede?",
                        "Hei! Når du slutter å røyke jobber hjernen med å gjenopprette balansen i signalstoffene. Derfor er det ikke uvanlig å føle seg litt nedstemt en periode. Føler du deg trist over lang tid, ta en prat med legen din."
                    }
                },
                {
                    "Penger", new string[] {
                        "Du sparer ikke bare penger, du vinner også bedre helse, kondisjon, smaksopplevelser, lukt osv. osv."
                    }
                },
                {
                    "Mine nærmeste", new string[] {
                        "De fleste barn med foreldre som røyker eller snuser ønsker seg en tobakksfri framtid."
                    }
                },
                {
                    "Utseende", new string[] {
                        "En kosmetolog kan med stor sikkerhet se på folks hud om de røyker. Gled deg over at din hud nå får den næringen den trenger."
                    }
                }
            }
        },
        {
            16, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hei! Ved å være røykfri er du et godt forbilde for dem rundt deg. Det har betydning for kollegaer, venner og dine nærmeste."
                    }
                }
            }
        },
        {
            17, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hei! Etter 2–4 år som røykfri, er faren for å utvikle hjerte- og karsykdom betydelig redusert."
                    }
                }
            }
        },
        {
            18, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hei! Å slutte å røyke gir både gode og dårlige dager. Det å savne røyken i enkelte situasjoner er en helt vanlig side av å bli røykfri. Hold motivasjonen oppe ved å minne seg selv på hvorfor du ville slutte."
                    }
                }
            }
        },
        {
            19, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hei! Du har klart deg mange dager uten å røyke! Bra jobba! Et morsomt bilde på røykeslutten er å regne ut hvor mange meter røyk du har unngått å inhalere. En vanlig sigarett er ca. 7cm lang."
                    }
                }
            }
        },
        {
            20, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hei. Gled deg over pengene du sparer."
                    }
                }
            }
        },
        {
            21, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Tre uker som røykfri. Vær stolt! Husk at du ikke behøver å gjøre dette alene. Du kan ta kontakt med en frisklivssentral i nærheten for flere råd og tips."
                    }
                }
            }
        },
        {
            22, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hei. Gled deg over at lukt- og smakssansene ikke lenger er bedøvet av røyking."
                    }
                }
            }
        },
        {
            23, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Unn deg selv en belønning for at du hver dag gjør det aller beste for helsa di som røykfri!"
                    }
                }
            }
        },
        {
            24, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gi deg selv ros, du har grunn til å være stolt."
                    }
                }
            }
        },
        {
            25, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hei! Du har vært røykfri mer enn tre uker og den fysiske avhengigheten av nikotin er snart borte. «Nikotintrollet» i hjernen får ikke lenger diktere hva du skal gjøre. Nå er det du som bestemmer! "
                    }
                }
            }
        },
        {
            26, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hei. Dette kommer til å gå bra! Fortsett på samme måte."
                    }
                }
            }
        },
        {
            27, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hei. Det gir mer overskudd å være røykfri."
                    }
                }
            }
        },
        {
            28, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Nå har du nådd de «magiske» 28 røykfrie dagene. Forskning viser at 28 røykfrie dager femdobler sjansen for å bli røykfri for godt. Det er det grunn til å feire!"
                    }
                }
            }
        },
        {
            29, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hei. Flimmerhårene begynner å vokse ut igjen etter røykeslutt. Det kan ta noen måneder før de er ferdig utvokst. Dersom du hoster mye kan det være flimmerhårene som våkner til liv."
                    }
                }
            }
        },
        {
            30, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hei. Har du regnet ut hvor mye penger du har unngått å bruke på røyk? Dersom du har spart, er det gøy å planlegge hva du kan bruke pengene til!"
                    }
                }
            }
        },
        {
            31, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hei. Mange synes de får bedre tid når de slutter. En ting mindre du skal rekke å gjøre!"
                    }
                }
            }
        },
        {
            32, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hei. Selv om du ikke røyker lenger har du behov for en god pause i ny og ne. Gi deg selv en velfortjent hvil i hverdagen."
                    }
                }
            }
        },
        {
            33, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hei! Nå har du kommet langt. Stå på videre!"
                    }
                }
            }
        },
        {
            34, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hei. ½ -3 måneder etter røykeslutt kan menn få bedre ereksjon og kvinner som ønsker å få barn øker sjansen for å bli gravide."
                    }
                }
            }
        },
        {
            35, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Fem uker uten røyk. Hvordan skal du feire?"
                    }
                }
            }
        },
        {
            36, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "En naturlig side ved å bli kvitt nikotinavhengigheten, er at tvilstankene kommer snikende. Husk at det er du som bestemmer! Lukk øynene og tenk på alt det positive du har oppnådd ved å bli røykfri."
                    }
                }
            }
        },
        {
            37, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Imponerende bra jobbet!"
                    }
                }
            }
        },
        {
            38, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Se for deg hvor mange sigaretter du har latt være å røyke. Det er godt for kroppen å slippe."
                    }
                }
            }
        },
        {
            39, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Det kan være tungt innimellom, og det er det helt vanlig å kjenne på det. Det går snart bedre!"
                    }
                }
            }
        },
        {
            40, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Så flott at du fortsatt er røykfri! Tenk så fornøyd du vil kjenne deg etter et halvt år som røykfri!"
                    }
                }
            }
        },
        {
            41, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hold motet oppe! Er det ikke deilig å kunne gå hjemmefra uten å måtte huske å ta med røyken?"
                    }
                }
            }
        },
        {
            42, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Nå har du klart hele seks uker som røykfri."
                    }
                }
            }
        },
        {
            43, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "For de fleste er det nå merkbart lettere å gå i trapper."
                    }
                }
            }
        },
        {
            44, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Har du lagt merke til at mange ting lukter mer og sterkere? For noen blir dette som å oppdage en helt ny verden. Tenk hvor deilig det er å vite at det ikke lenger lukter røyk av deg!"
                    }
                }
            }
        },
        {
            45, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hei! Smaker det mer og bedre av maten nå? Tygg sakte og nyt det!"
                    }
                }
            }
        },
        {
            46, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "På tide å skryte av deg selv. Fortell det til noen du kjenner!"
                    }
                }
            }
        },
        {
            47, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Har du sett at huden din har fått friskere farge? Som røykfri får både små og store blodårer bedre blodgjennomstrømning."
                    }
                }
            }
        },
        {
            48, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Å endre vaner kan være slitsomt. Gjør noe du liker for å lade batteriene!"
                    }
                }
            }
        },
        {
            49, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Sju uker som røykfri! Kroppen din elsker deg for det!"
                    }
                }
            }
        },
        {
            50, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Kiler det fortsatt litt i halsen? Fornøyde flimmerhår våkner til liv igjen for hver dag som går."
                    }
                }
            }
        },
        {
            51, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hvis du trenger støtte, snakk med en venn eller kollega. Det hjelper å si høyt hvorfor du sluttet og hva du var redd for dersom du fortsatte å røyke."
                    }
                }
            }
        },
        {
            52, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Fakta: røyk inneholder terpentin, arsenikk og loppedrepende middel. Det er godt for kroppen å slippe!"
                    }
                }
            }
        },
        {
            53, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Mye tid til overs nå som du er røykfri? Legg planer for å gjøre noe du ikke pleier å gjøre."
                    }
                }
            }
        },
        {
            54, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Nå har du sannsynligvis fått bedre blodsirkulasjon til ryggvirvlene og dermed redusert risikoen for ryggproblemer."
                    }
                }
            }
        },
        {
            55, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Du sparer penger. Mange penger!"
                    }
                }
            }
        },
        {
            56, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer. Åtte uker røykfri i dag! Utrolig bra."
                    }
                }
            }
        },
        {
            57, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Samtidig som du sparer penger er du i ferd med å gjøre en kjempeinvestering for alderdommen din! Friskere lunger og hjerte vil gi økt overskudd resten av livet ditt."
                    }
                }
            }
        },
        {
            58, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Du har nå vist i flere uker at du har kontroll. Du er sjefen!"
                    }
                }
            }
        },
        {
            59, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Du fortjener å ha en frisk kropp!"
                    }
                }
            }
        },
        {
            60, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "60 dager uten røyk. Hvor mange penger har du spart til nå? Det er fortsatt viktig å minne seg selv på de positive tingene ved ikke å røyke. "
                    }
                }
            }
        },
        {
            63, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært røykfri i 9 uker."
                    }
                }
            }
        },
        {
            70, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært røykfri i 10 uker."
                    }
                }
            }
        },
        {
            77, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært røykfri i 11 uker."
                    }
                }
            }
        },
        {
            84, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært røykfri i 12 uker."
                    }
                }
            }
        },
        {
            91, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært røykfri i 13 uker."
                    }
                }
            }
        },
        {
            98, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært røykfri i 14 uker."
                    }
                }
            }
        },
        {
            105, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært røykfri i 15 uker."
                    }
                }
            }
        },
        {
            112, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært røykfri i 16 uker."
                    }
                }
            }
        },
        {
            119, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært røykfri i 17 uker."
                    }
                }
            }
        },
        {
            126, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært røykfri i 18 uker."
                    }
                }
            }
        },
        {
            133, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært røykfri i 19 uker."
                    }
                }
            }
        },
        {
            140, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært røykfri i 20 uker."
                    }
                }
            }
        },
        {
            147, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært røykfri i 21 uker."
                    }
                }
            }
        },
        {
            154, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært røykfri i 22 uker."
                    }
                }
            }
        },
        {
            161, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært røykfri i 23 uker."
                    }
                }
            }
        },
        {
            168, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært røykfri i 24 uker."
                    }
                }
            }
        },
        {
            175, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært røykfri i 25 uker."
                    }
                }
            }
        },
        {
            182, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært røykfri i 26 uker."
                    }
                }
            }
        },
        {
            189, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært røykfri i 27 uker."
                    }
                }
            }
        },
        {
            217, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært røykfri i 31 uker."
                    }
                }
            }
        },
        {
            245, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært røykfri i 35 uker."
                    }
                }
            }
        },
        {
            273, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært røykfri i 39 uker."
                    }
                }
            }
        },
        {
            301, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært røykfri i 43 uker."
                    }
                }
            }
        },
        {
            329, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært røykfri i 47 uker."
                    }
                }
            }
        },
        {
            357, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært røykfri i 51 uker."
                    }
                }
            }
        },
        {
            365, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hipp hurra – ett år uten røyk!"
                    }
                }
            }
        }
    };

    public static readonly Dictionary<int, Dictionary<string, string[]>> LocalNotifsSnus = new Dictionary<int, Dictionary<string, string[]>>()
    {
        {
            -10, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Nå er det ikke lenge til du skal slutte å snuse. Du kan gjøre flere av de samme forberedelsene som en idrettsutøver må gjennom før en konkurranse. En metode som idrettsfolk ofte bruker er såkalt mental trening. Det vil si at de lager seg et indre bilde av konkurransen og ser seg selv som vinneren. Det kan du også prøve for å slutte å snuse."
                    }
                }
            }
        },
        {
            -9, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Lag deg en liste over alt du kommer på som skal til for å slutte å snuse. Ha listen lett tilgjengelig og legg til nye ting etter hvert som du kommer på dem."
                    }
                }
            }
        },
        {
            -8, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Prøv å skrive opp hvor mye du snuser hver dag. Senere kan du se om det er enkelte dager du snuste ekstra mye. Prøv å finne ut hvorfor du snuste så mye akkurat disse dagene, og vær forberedt hvis det oppstår liknende situasjoner."
                    }
                }
            }
        },
        {
            -7, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Lag deg snusfrie soner, og bestem deg for aldri mer å snuse der. Det kan være på vei til skole eller jobb, i bilen eller hjemme hos deg selv."
                    }
                }
            }
        },
        {
            -6, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Prøv å bryte noen koblinger mellom situasjoner og snus. Det kan være den første snusen du tar om morgenen eller den etter middag. Koblingen forsvinner gradvis når du har vært gjennom dem noen ganger uten å snuse."
                    }
                }
            }
        },
        {
            -5, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Prøv å tenke ut noe du liker å drive med og som kan holde deg i aktivitet når du slutter. Det kan forebygge rastløshet."
                    }
                }
            }
        },
        {
            -4, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Noter ned alle de positive sidene du kan tenke deg ved å slutte å snuse."
                    }
                }
            }
        },
        {
            -3, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Lag en plan for hva du skal gjøre når nikotinsuget melder seg. Tenk gjennom hva du vil gjøre – noe som tar oppmerksomheten din bort fra det."
                    }
                }
            }
        },
        {
            -2, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Informer dine nærmeste om at du skal slutte - og be om støtte."
                    }
                }
            }
        },
        {
            -1, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Fjern snus og snusbokser, og gjør hjemmet ditt til en snusfri sone. Se for deg hvordan det er å være snusfri og hva du skal gjøre i situasjoner der du ellers ville tatt en snus. Nå starter ditt nye liv uten snus!"
                    }
                }
            }
        },
        {
            0, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hei! Det at du har valgt å slutte å snuse vil påvirke kroppen din og livet ditt positivt på flere måter enn du tror. Dette vil vi fortelle deg litt om i meldingene du mottar på mobilen din i tiden fremover. Lykke til!",
                        "Snusånden din er snart borte. Abstinenser kommer av at hjernen din ikke lenger tilføres nikotin fra snus. Suget etter snus varer i noen minutter om gangen, så fatt mot – du tåler mer enn du tror!"
                    }
                },
                {
                    "Penger", new string[] {
                        "Hei. Du sparer penger for hver røyk eller snus du ikke tar i dag og i tiden framover. Dessuten er det å slutte med tobakk det viktigste du gjør for helsen din."
                    }
                },
                {
                    "Mine nærmeste", new string[] {
                        "Hei. Å slutte å røyke og snuse er det viktigste du gjør for helsen din. Det har stor betydning for dine nærmeste at du har valgt å slutte!"
                    }
                },
                {
                    "Utseende", new string[] {
                        "Hei. Å slutte med tobakk er det viktigste du gjør for helsen din. Og du bremser også aldringsprosessen!"
                    }
                }
            }
        },
        {
            1, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Vær forberedt på at du kan kjenne et savn etter snus i noen situasjoner, for eksempel etter at du har spist eller i sosiale sammenhenger. Legg en plan for hvordan du skal takle det.",
                        "Snus inneholder mye nikotin. Den fysiske avhengigheten merkes når du skal slutte å snuse. Da kan abstinensplager som hjertebank, kaldsvette og hodepine forekomme. Spis sunt og regelmessig, for da fungerer kroppen din bedre og suget etter snus blir lettere å tåle.",
                        "Hei! Du er over den første dagen. Bra! Husk at abstinensplagene er verst de første dagene, og forsvinner gradvis.",
                        "Gratulerer! Du har vært snusfri i 24 timer."
                    }
                }
            }
        },
        {
            2, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Rastløshet, irritasjon og uro er vanlige plager når man slutter med snus. Minn deg selv på at det er midlertidig og at det vil bli bedre! Få i deg nok væske og vær aktiv.",
                        "Trenger du støtte? Snakk med en venn eller kollega. Det hjelper å høre seg selv si hvorfor det er viktig å slutte med snus nå, og hva du var bekymret for ved fortsatt snusing.",
                        "Hei! En studie tyder på at å slutte med snus reduserer risikoen for skader ved trening. Dette kan forklares ved at nikotinet i snus reduserer nerveoverføringen i muskler og gir redusert blodtilførsel. Det er også en risiko for at skader i vev og muskler heles saktere når du bruker snus.",
                        "Gratulerer! Du har vært snusfri i 48 timer."
                    }
                },
                {
                    "Mine nærmeste", new string[] {
                        "Hei. Ved å slutte med tobakk beskytter du de du er mest glad i. Vær forberedt på at kroppen din nå jobber med å bli kvitt avhengigheten og du kan svette mer enn vanlig. Husk å drikke mye vann."
                    }
                },
                {
                    "Utseende", new string[] {
                        "Hei. Nå slipper du å bekymre deg for flere og dypere rynker. Vær forberedt på at kroppen din jobber med å bli kvitt avhengigheten og du kan svette mer enn vanlig. Husk å drikke mye vann."
                    }
                }
            }
        },
        {
            3, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hjertet jobber normalt når du ikke snuser. Nikotinet i snusen får blodårene til å trekke seg sammen, og både pulsen og blodtrykket stiger.",
                        "Hodepine er vanlig i forbindelse med snusslutt. Dette kan skyldes økt stress og forbigående senkning av blodsukkeret og blodtrykket. Trening, vann og avslapning kan hjelpe.",
                        "Hei! Du kan oppleve at du tåler mindre kaffe og cola når du slutter å snuse fordi koffeinet forbrennes saktere. For mye koffein kan forveksles med abstinensplager.",
                        "Gratulerer! Du har vært snusfri i 72 timer."
                    }
                },
                {
                    "Penger", new string[] {
                        "Abstinensplagene er verst de første dagene, fortsett å holde ut, du er snart over det. Og gled deg over pengene du sparer!"
                    }
                },
                {
                    "Mine nærmeste", new string[] {
                        "Den fysiske avhengigheten er verst de første dagene, fortsett å holde ut, du er snart over det."
                    }
                },
                {
                    "Utseende", new string[] {
                        "Blodsirkulasjonen blir bedre raskt etter at du slutter. Selv om du ikke har merket det enda er dette bra for både hud og hår. Den fysiske avhengigheten er verst de første dagene, fortsett å holde ut, du er snart over det. "
                    }
                }
            }
        },
        {
            4, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Beveg deg. En rask gåtur får deg til å tenke på noe annet, lindrer abstinens og demper trangen til å snuse.",
                        "Lurer du på noe om snus og helseskader, se slutta.no. Snakk med legen din hvis du har spørsmål om egen helse.",
                        "Hei! Du sparer penger for hver snus du ikke tar. Et godt råd er å legge pengene til side, slik at du ser hvor mange penger du sparer."
                    }
                },
                {
                    "Penger", new string[] {
                        "Det å slutte er godt for både kroppen og lommeboka. Dersom du trener, får du nå bedre utbytte av treningen."
                    }
                },
                {
                    "Mine nærmeste", new string[] {
                        "Din beslutning om å slutte har positive helseeffekter for dem rundt deg. Og dersom du trener, får du nå bedre utbytte av treningen."
                    }
                },
                {
                    "Utseende", new string[] {
                        "Dersom du trener, får du nå bedre utbytte av treningen. Trening stimulerer også blodomløpet, slik at det blir lettere for hud og hår å utnytte næringen du har fått i deg."
                    }
                }
            }
        },
        {
            5, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Du kan bruke pusten til å stresse ned. Legg deg gjerne ned på gulvet, pust inn med nesen og dypt ned i magen. Pust ut gjennom munnen samtidig som du lager en aaaah-lyd som signaliserer til kroppen at den skal slappe av.",
                        "Dersom du synes du svetter mer enn du pleier eller er litt svimmel, så er det vanlige plager ved snusslutt. Drikk godt med vann og husk at det blir bedre!",
                        "Hei! Har du problemer med å sove? Å slutte å snuse innebærer en forandring for kroppen, og nervesystemet ditt skal omstille seg. Det hjelper om du er litt fysisk aktiv og unngår koffein på kveldstid."
                    }
                }
            }
        },
        {
            6, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Sparer du pengene du tidligere brukte på snus, kan du begynne å planlegge hva du kan kjøpe i stedet for!",
                        "Å slutte med snus hindrer videre utvikling av skader på tannkjøtt og de aller fleste skader på slimhinnen i munnen blir borte.",
                        "Hei! Tror du at du kommer til å bli fristet hvis andre rundt deg snuser? Da kan det være lurt å forberede deg før du står midt oppe i det. Øv deg på å si: Nei takk, jeg snuser ikke!"
                    }
                },
                {
                    "Penger", new string[] {
                        "Tenk på hvordan du vil bruke pengene du sparer. Nikotinsug kan forveksles med sultfølelse. Finn ut om du er sulten eller nikotinsugen, og gjør nødvendige tiltak. Spis litt eller få oppmerksomheten over på noe helt annet."
                    }
                },
                {
                    "Mine nærmeste", new string[] {
                        "Å slutte med tobakk øker sjansen for unngå alvorlig sykdom. Det gir muligheten for flere bursdager, bryllupsdager eller cupfinaler sammen med dem du er glad i. Nikotinsug kan forveksles med sultfølelse. Finn ut om du er sulten eller nikotinsugen, og gjør nødvendige tiltak. Spis litt eller få oppmerksomheten over på noe helt annet."
                    }
                },
                {
                    "Utseende", new string[] {
                        "Som tobakksfri har du bedre blodgjennomstrømning, og alle sår gror bedre. Husk at dette er en forutsetning for å unngå stygge arrdannelser og for igangsettelse av flere typer operasjoner. Nikotinsug kan forveksles med sultfølelse. Finn ut om du er sulten eller nikotinsugen, og gjør nødvendige tiltak. Spis litt eller få oppmerksomheten over på noe helt annet."
                    }
                }
            }
        },
        {
            7, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Det er helt vanlig med dager hvor motivasjonen virker tynnslitt. Da hjelper det å minne deg selv på grunnene du har for å slutte.",
                        "Høyt forbruk av snus økter risikoen for diabetes type 2.",
                        "Gratulerer! Du har klart en uke som snusfri. For noen hjelper det å fortelle andre om sitt slutteprosjekt. Det kan gjøre det lettere å holde motivasjonen oppe.",
                        "Gratulerer! Du har vært snusfri i en uke."
                    }
                }
            }
        },
        {
            8, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Husk at hver gang du motstår trangen til snus, øker du din kontroll!",
                        "Hei! Du har passert over en uke som snusfri! Trangen til å snuse vil fortsatt komme og gå, men du har bevist at det går uten. Bra jobba!"
                    }
                }
            }
        },
        {
            9, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Som snusfri sparer du deg for mer enn 30 kreftfremkallende stoffer. Stoffene i snus som øker kreftrisikoen er først og fremst nitrosaminer og tungmetaller.",
                        "Hei! Forsøk gjerne å bruke fysisk aktivitet som distraksjon. Det hjelper mot suget etter snus."
                    }
                }
            }
        },
        {
            10, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "De fleste som snuser begynte sammen med venner eller kjæresten. Tenk gjennom hva du skal svare hvis de spør om du vil ha.",
                        "Hei! Dersom du får mer lyst på noe søtt å spise nå som du er snusfri, ha med deg noe enkelt å spise, som frukt, grønnsaker eller nøtter!"
                    }
                }
            }
        },
        {
            11, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hold ut! Kroppen din er ikke lenger fysisk avhengig av nikotin 2-4 uker etter snusslutt.",
                        "Hei! Det er ikke uvanlig å føle seg litt nedstemt når du slutter. Hjernen jobber med å gjenopprette balansen i signalstoffene i hjernen. Om du føler deg trist over lang tid kan du ta en prat med legen din."
                    }
                }
            }
        },
        {
            12, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Du kan merke at det blir vanskeligere å la være å snuse dersom du drikker alkohol. Bestem deg på forhånd for hva du skal gjøre hvis du får lyst på snus.",
                        "Hei! På slutta.no finnes informasjon om snus, helseskader og vanlige abstinenser. Har du spørsmål om egen helse, snakk med legen din."
                    }
                }
            }
        },
        {
            13, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hei! Dersom du har hatt en glipp, så vit at det er helt normalt! Velg å fortsette. Bruk erfaringene til å legge en plan for neste gang fristelser dukker opp. Ikke gi deg! Øvelse gjør mester."
                    }
                }
            }
        },
        {
            14, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer med to uker uten snus! Du er flink!"
                    }
                },
                {
                    "Penger", new string[] {
                        "Når du slutter har du mer romslig økonomi. Det betyr litt mer hverdagsluksus, flere ferier, aktiviteter med familien og gaver til personer du er glad i."
                    }
                },
                {
                    "Mine nærmeste", new string[] {
                        "Når du slutter har du mer romslig økonomi. Det betyr litt mer hverdagsluksus, flere ferier, aktiviteter med familien og gaver til personer du er glad i."
                    }
                },
                {
                    "Utseende", new string[] {
                        "Snusslutt er bra for tennene. Snusing svekker forsvaret mot bakteriebelegg og gir økt risiko for tannkjøttbetennelsen periodontitt. I verste fall kan det føre til at tennene løsner."
                    }
                }
            }
        },
        {
            15, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hvis du sliter, kan du ta en prat med en venn eller kollega. Å høre seg selv si hvorfor det er viktig å slutte gir deg mer lyst og tro på at du skal klare det!"
                    }
                },
                {
                    "Penger", new string[] {
                        "Du sparer ikke bare penger, du vinner også bedre helse, kondisjon, smaksopplevelser, lukt osv. osv."
                    }
                },
                {
                    "Mine nærmeste", new string[] {
                        "De fleste barn med foreldre som røyker eller snuser ønsker seg en tobakksfri framtid."
                    }
                },
                {
                    "Utseende", new string[] {
                        "En kosmetolog kan med stor sikkerhet se på folks hud om de snuser. Gled deg over at din hud nå får den næringen den trenger."
                    }
                }
            }
        },
        {
            16, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hei! Gled deg over at du nå ikke har økt risiko for å utvikle diabetes 2. "
                    }
                }
            }
        },
        {
            17, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Dersom du er mindre motivert i perioder, så skal du vite at det er helt vanlig og at de fleste som slutter, opplever dette. Gi deg selv et klapp på skulderen for å holde ut når motivasjonen er lav."
                    }
                }
            }
        },
        {
            18, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hei! Det er fint å vite at du ikke lenger utsetter tennene dine for snus. Stimuler munnen med andre ting, for eksempel tannpirkere eller tyggegummi. "
                    }
                }
            }
        },
        {
            19, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hei! De fleste endringene i munnslimhinnene går tilbake etter snusslutt og slimhinnene leges."
                    }
                }
            }
        },
        {
            20, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hei. Sjekk hvor mange penger du har spart."
                    }
                }
            }
        },
        {
            21, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Tre uker som snusfri. Vær stolt!"
                    }
                }
            }
        },
        {
            22, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hei. Snusbruk synes å ha en sammenheng med den alvorlige kreftformen bukspyttkjertelkreft. Snusslutt er bra for helsa!"
                    }
                }
            }
        },
        {
            23, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Forestill deg hvor glad du blir i morgen fordi du fortsatt klarer deg uten snus!"
                    }
                }
            }
        },
        {
            24, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hei! Kjenner du på savnet etter snus i enkelte situasjoner? Husk tilbake på hvorfor du bestemte deg for å slutte."
                    }
                }
            }
        },
        {
            25, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Nå slipper du å få i deg giftige stoffer som kvikksølv, arsenikk og radioaktivt polonium."
                    }
                }
            }
        },
        {
            26, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hvis du trenger hjelp til å takle enkelte situasjoner, hør gjerne hva andre du kjenner har gjort. Det finnes mange måter å holde ut på!"
                    }
                }
            }
        },
        {
            27, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Du er nå kommet så langt at du ikke lenger er fysisk avhengig av nikotin. Savnet kan likevel dukke opp innimellom. Men du vet hvordan du skal takle det."
                    }
                }
            }
        },
        {
            28, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Nå har du vært snusfri i fire uker. Knallbra jobba!"
                    }
                }
            }
        },
        {
            29, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hei! Ved å være snusfri er du et godt forbilde for dem rundt deg! Det har betydning for venner, kollegaer og dine nærmeste."
                    }
                }
            }
        },
        {
            30, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Det er imponerende at du er kommet så langt! Nå gjelder det å fortsette som før og holde fast på målet."
                    }
                }
            }
        },
        {
            31, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Det finnes gode grunner for å la være å snuse, og i fremtiden kommer du ikke til å angre på at du tok vare på kroppen og helsa di."
                    }
                }
            }
        },
        {
            32, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Over en måned er lang tid! Husk at du finner tips og hjelp på slutta.no dersom du skulle trenge det en dag."
                    }
                }
            }
        },
        {
            33, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Forestill deg hvor stolt du er når du har klart et helt år uten snus!"
                    }
                }
            }
        },
        {
            34, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Se for deg hvor mange snus du har latt være å ta. Det er godt for kroppen å slippe."
                    }
                }
            }
        },
        {
            35, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Nå er det fem uker siden du slutta. Bravo!"
                    }
                }
            }
        },
        {
            36, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Har du fortalt noen hvor flink du er? Husk at du også kan motivere andre."
                    }
                }
            }
        },
        {
            37, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Nå har du kommet langt! Ikke lur deg selv til å bare ta én snus igjen. Det fører gjerne til en til og en til og en til. Det er en klisjé å si det, og derfor så sant at det bare er én snus du skal passe deg for: den neste."
                    }
                }
            }
        },
        {
            38, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Det blir en fin dag. Minn deg selv på alt du har klart!"
                    }
                }
            }
        },
        {
            39, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Ingen grunn til å la dagen i går være bedre enn i dag, nyt nuet!"
                    }
                }
            }
        },
        {
            40, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Selv om du ikke snuser lenger har du behov for hvile, avslapning eller en pause fra vanskelige situasjoner. Så gi deg selv gode pauser i hverdagen."
                    }
                }
            }
        },
        {
            41, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Dagene kan svinge og kanskje kan det være tungt innimellom. Bestem deg for å tåle det! Sånn er livet."
                    }
                }
            }
        },
        {
            42, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer med seks uker som snusfri! Dette går rette veien!"
                    }
                }
            }
        },
        {
            43, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Se for deg haugen av snus du har latt være å putte under leppa. Det er godt for kroppen å slippe!"
                    }
                }
            }
        },
        {
            44, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Så flott at du fortsatt er snusfri! Tenk så mange penger du har spart – og kommer til å spare! "
                    }
                }
            }
        },
        {
            45, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hei. Ros deg selv – det fortjener du!"
                    }
                }
            }
        },
        {
            46, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Det er deilig å gå hjemmefra uten å måtte lete etter snusen."
                    }
                }
            }
        },
        {
            47, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hei. Hold fast på avgjørelsen din!"
                    }
                }
            }
        },
        {
            48, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Får du nok skryt? Hvis ikke – be om det!"
                    }
                }
            }
        },
        {
            49, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer med sju uker uten snus! Selv om du av og til kjenner et savn, har du nå bevist at det går an å være uten. "
                    }
                }
            }
        },
        {
            50, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Trenger du mer hjelp? Gå inn på slutta.no."
                    }
                }
            }
        },
        {
            51, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Etter så mange snusfrie dager er det lett å glemme hvor avhengig man egentlig var. Dersom fristelse dukker opp, ikke gi etter og tro at du kan klare å snuse bare litt."
                    }
                }
            }
        },
        {
            52, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Minn deg selv på de gode sidene ved å ha sluttet! Frihet og penger for eksempel!"
                    }
                }
            }
        },
        {
            53, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Husk at du slipper jaget etter snus! Det dominerer ikke livet lenger."
                    }
                }
            }
        },
        {
            54, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Du sparer penger for hver dag."
                    }
                }
            }
        },
        {
            55, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Har du tatt en kikk under leppa? Er sporene etter snusingen borte?"
                    }
                }
            }
        },
        {
            56, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Vær stolt over beslutningen du tok for åtte uker siden!"
                    }
                }
            }
        },
        {
            57, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hei. Du har vært gjennom gode og dårlige dager. Det er godt gjort å ha kommet så langt."
                    }
                }
            }
        },
        {
            58, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Du fortjener å ha en frisk kropp! Å la være å snuse er klokt!"
                    }
                }
            }
        },
        {
            59, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Nå har du hatt kontrollen i 59 dager! Hvordan føles det?"
                    }
                }
            }
        },
        {
            60, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "60 dager uten snus! Du fortjener en belønning!"
                    }
                }
            }
        },
        {
            63, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært snusfri i 9 uker."
                    }
                }
            }
        },
        {
            70, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært snusfri i 10 uker."
                    }
                }
            }
        },
        {
            77, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært snusfri i 11 uker."
                    }
                }
            }
        },
        {
            84, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært snusfri i 12 uker."
                    }
                }
            }
        },
        {
            91, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært snusfri i 13 uker."
                    }
                }
            }
        },
        {
            98, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært snusfri i 14 uker."
                    }
                }
            }
        },
        {
            105, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært snusfri i 15 uker."
                    }
                }
            }
        },
        {
            112, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært snusfri i 16 uker."
                    }
                }
            }
        },
        {
            119, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært snusfri i 17 uker."
                    }
                }
            }
        },
        {
            126, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært snusfri i 18 uker."
                    }
                }
            }
        },
        {
            133, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært snusfri i 19 uker."
                    }
                }
            }
        },
        {
            140, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært snusfri i 20 uker."
                    }
                }
            }
        },
        {
            147, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært snusfri i 21 uker."
                    }
                }
            }
        },
        {
            154, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært snusfri i 22 uker."
                    }
                }
            }
        },
        {
            161, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært snusfri i 23 uker."
                    }
                }
            }
        },
        {
            168, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært snusfri i 24 uker."
                    }
                }
            }
        },
        {
            175, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært snusfri i 25 uker."
                    }
                }
            }
        },
        {
            182, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært snusfri i 26 uker."
                    }
                }
            }
        },
        {
            189, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært snusfri i 27 uker."
                    }
                }
            }
        },
        {
            217, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært snusfri i 31 uker."
                    }
                }
            }
        },
        {
            245, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært snusfri i 35 uker."
                    }
                }
            }
        },
        {
            273, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært snusfri i 39 uker."
                    }
                }
            }
        },
        {
            301, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært snusfri i 43 uker."
                    }
                }
            }
        },
        {
            329, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært snusfri i 47 uker."
                    }
                }
            }
        },
        {
            357, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Gratulerer! Du har vært snusfri i 51 uker."
                    }
                }
            }
        },
        {
            365, new Dictionary<string, string[]>() {
                {
                    "MANDATORY", new string[] {
                        "Hipp hurra – ett år uten snus!"
                    }
                }
            }
        }
    };
}
