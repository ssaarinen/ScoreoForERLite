# Käyttöohjeet ScoreOForEResultsLite:lle

ScoreOForEResultsLite on yksinkertainen sovellus, joka laskee Score-O / Rogaining -tyylisiä tuloksia
[EResults Lite](https://www.oriento.fi/eresults/lite) -sovelluksella kerätyistä suunnistustuloksista.

## Asennus

Sovellus on saatavilla Microsoft Storesta: [Web linkki](https://apps.microsoft.com/detail/9n50r1gndn4t). 
EResults Lite on myös tarpeen ja se voidaan ladata [Orienton](https://www.oriento.fi/eresults/lite) sivuilta.

Asennuksen jälkeen käynnistä sovellus Käynnistä-valikosta tai etsimällä "ScoreOForEResultsLite".

## Käyttö

Käytä sovellusta suunnistustapahtumassa seuraavasti:

1. Luo uusi kilpailu EResults Lite -sovelluksessa ja tallenna se tiedostoon, esimerkiksi `tulokset.json`.
2. Avaa sama kilpailutiedosto ScoreOForEResultsLite-sovelluksessa valitsemalla *Tiedosto* -> *Avaa* tai raahaa tiedosto
   sovellusikkunaan.
3. Kun tulokset luetaan EResults Liteen, ne ovat automaattisesti saatavilla ScoreOForEResultsLite-sovelluksessa;
   viimeisin tulos korostetaan tuloslistassa. Kaksoisklikkaa mitä tahansa tulosta avataksesi sen yksityiskohtaisen
   näkymän.
4. Voit halutessasi ottaa käyttöön *Näkymä* -> *Avaa uusin tulos automaattisesti*, jolloin yksityiskohtainen näkymä avautuu
   automaattisesti, kun uusi tulos vastaanotetaan.

### Lentävä lähtö tai yhteislähtö

Lentävä- ja yhteislähtö lasketaan samalla tavalla, kuin EResults Litessä. Oletuksena käytetään nollaleimasimen aikaa 
kilpailijan ajan laskemiseen.  Jos kilpailijalle merkitään lähtöaika, käytetään sitä tuloslaskennassa nollaleimasinajan
sijaan. Yhteislähdössä pitää kaikille kilpailijoille merkitä sama lähtöaika EResults Litessä.

## Sarjat
EResults Lite ei tue erillisiä sarjoja, joten niitä ei ole käytössä myöskään ScoreOForEResultsLite-sovelluksessa.

## Asetukset

Avaa asetukset valitsemalla *Tiedosto* -> *Asetukset*. Asetuksia voi muuttaa milloin tahansa ja kaikki tulokset
lasketaan uudelleen uusilla asetuksilla, kun asetusikkuna suljetaan. Asetukset tallennetaan automaattisesti sovelluksen sulkeutuessa ja ne
ladataan uudelleen sovelluksen käynnistyessä.

Seuraavat asetukset ovat käytettävissä:

### Yleiset
- **Maalileimasimen koodi**: Koodi, joka ilmaisee kilpailun maalin. Maalileiman jälkeiset leimat jätetään huomiotta
  tuloslaskennassa. Oletus: `100`.
- **Lähtöleimasimen koodi**: Koodi, joka ilmaisee lähtöleimasimen. Oletus: `0` (ei tällä hetkellä muokattavissa asetuksista).
- **Lukijaleimasimen koodi**: Koodi, joka ilmaisee lukijaleimasimen. Oletus: `250` (ei tällä hetkellä muokattavissa
  asetuksista).

### Pisteenlasku
- **Suoritusaika (formaatti: hh:mm:ss)**: Kilpailun sallittu maksimiaika. Kilpailijat, jotka saapuvat maaliin tämän ajan
  jälkeen, saavat sakkopisteitä.
- **Sakkoaikaväli (sekuntia)**: Aikarajaväli, jota käytetään sakkopisteiden laskemisessa; jokaisesta alkaneesta
  sakkovälistä maksimiajan jälkeen lisätään sakkopisteitä.
- **Sakko aikaväliltä**: Sakkopisteet, jotka lisätään jokaista maksimiajan ylittävää sakkoväliä kohden. Esimerkki:
  jos maksimiaika on `1:00:00`, sakkoväli `60` s ja sakko aikaväliltä `1` piste, kilpailija joka saapuu aikaan
  `1:02:01` saa `3` sakkopistettä (3 väliä x 1 piste).
- **Sallitut rastikoodit**: Pilkuin eroteltu lista rastikoodeista ja tarvittaessa näiden pistearvoista. Listaamattomat
  rastit jätetään pois pistelaskusta. Voit antaa rasteille pisteet manuaalisesti muodossa `koodi1[:pisteet1],koodiN[:pisteetN]`. Esimerkki:
  `31,32:5,33:10,80,91` tarkoittaa, että rasti `32` => 5 pistettä, rasti `33` => 10 pistettä; rastien `31`, `80` ja `91`
  pisteet lasketaan pisteenlaskukaavalla.
- **Pisteenlaskukaava**: Pisteenlaskukaavaa käytetään laskemaan pisteet niille sallituille rasteille, joille ei ole annettu
  manuaalisesti pisteitä. Sovelluksen tarjoamat vaihtoehdot ovat:
  - **Code = points**: Rastikoodi vastaa annettavia pisteitä. Esimerkiksi rasti `31` => 31 pistettä.
  - **First number = points**: Rastikoodin etuosa käytetään pisteinä. Esimerkit: rasti `31` => 3 pistettä; rasti
    `125` => 12 pistettä.
  - **First number = points (max 10)**: Sama kuin edellä, mutta pisteet rajataan enintään 10 pisteeseen. Esimerkit:
    rasti `31` => 3 pistettä; rasti `125` => 10 pistettä.

### Asetusten tallentaminen EResults Lite -kilpailutiedostoon

Voit tallentaa asetukset EResults Lite -kilpailutiedostoon asetukset-ikkunasta:

1. Avaa *Tiedosto* -> *Asetukset*.
2. Säädä asetukset haluamallasi tavalla.
3. Valitse *Toiminnot* -> *Kopioi leikepöydälle*.
4. EResults Litessä muokkaa kilpailua ja lisää uusi rata haluamallasi nimellä (esimerkiksi "ScoreO"). Liitä leikepöydän
   sisältö radan rastitietoihin. Liitetty teksti näyttää suunnilleen seuraavalta esimerkiltä:

```
@SV=1;eyJNVFMiOiIzNjAwIiwiUElTIjoiNjAiLCJQUEUEkiOiIxIiwiU0YiOiIxc3QgbnVtYmVyID0gcG9pbnRzIiwiQUMiOiIzMSwzMiwzMywzNCwzNSwzNiwzNyw0MSw0Miw0Myw0NCw0NSw1MSw1Miw1Myw1NCw1NSw2MSw3Nyw5MCw5MSIsIkZDIjoiOTIifQ==
```

### Tallennettujen asetusten lataaminen EResults Lite -kilpailusta

Jos olet aiemmin tallentanut asetuksia EResults Lite -kilpailutiedostoon yllä kuvatulla tavalla, voit ladata ne takaisin
ScoreOForEResultsLite-sovellukseen avaamalla *Tiedosto* -> *Asetukset* ja valitsemalla *Toiminnot* -> *Lataa kilpailutiedostosta*.
Toiminto on käytettävissä vain, jos avatussa kilpailutiedostossa on tallennettuja asetuksia.

## Tulosten vienti

Tulokset voidaan viedä HTML-muotoon verkkosivuille julkaisemista varten:

1. Pääikkunassa valitse *Tiedosto* -> *Vie tulokset* -> *HTML...*.
2. Valitse vietävät tulos- ja väliaikatiedostot ja anna tapahtumalle otsikko (tai hyväksy oletukset).
3. Klikkaa *Vie* luodaksesi HTML-tiedostot. Huomaa, että olemassa olevat samannimiset tiedostot ylikirjoitetaan.

## "Ei tulosta" tai "Ei nimeä tuloksiin"

Vain EResults Liten "OK"-tilassa olevat kilpailijat pisteytetään. Lisäksi kilpailijalla on oltava vähintään lähtö-,
maali- ja lukijaleimat, jotta pisteitä voidaan laskea. Jos kilpailija on merkitty EResults Litessä "Ei nimeä tuloksiin",
kilpailijan tulos sisältyy vietyihin tuloksiin, mutta ilman nimeä.
