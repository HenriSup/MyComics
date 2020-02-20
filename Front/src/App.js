import React, { Component } from 'react';
import './App.css';
import Tuiles from './Tuiles';
import category from './Category';
import HeaderDefault from './HeaderDefault'
import herolarge from './img/herolarge.jpg';
import Garfield from './img/Garfield.png'
import Favoris from './Favoris'
import Titre from './Titre'
import Auteur from './Auteur'
import Footer from './Footer'
import Slider from './components/NetflixSlider'

const movies = [
  {
    id: 1,
    image: '/images/slide1.jpg',
    imageBg: '/images/slide1b.webp',
    title: '1983'
  },
  {
    id: 2,
    image: '/images/slide2.jpg',
    imageBg: '/images/slide2b.webp',
    title: 'Russian doll'
  },
  {
    id: 3,
    image: '/images/slide3.jpg',
    imageBg: '/images/slide3b.webp',
    title: 'The rain',
  },
  {
    id: 4,
    image: '/images/slide4.jpg',
    imageBg: '/images/slide4b.webp',
    title: 'Sex education'
  },
  {
    id: 5,
    image: '/images/slide5.jpg',
    imageBg: '/images/slide5b.webp',
    title: 'Elite'
  },
  {
    id: 6,
    image: '/images/slide6.jpg',
    imageBg: '/images/slide6b.webp',
    title: 'Black mirror'
  }
];

class App extends Component {

  state = {
    category
  }

  render() {

    const categoryName = Object.keys(this.state.category).map(key => {
      return (
        <Tuiles name={key} />
      )
    })

    return (
      <div className="App">
        <link href="https://fonts.googleapis.com/css?family=Pacifico|Roboto&display=swap" rel="stylesheet"></link>
        <link href="https://fonts.googleapis.com/css?family=Kalam&display=swap" rel="stylesheet"></link>
        <link rel="stylesheet" href="owlcarousel/owl.carousel.min.css"></link>
        <link rel="stylesheet" href="owlcarousel/owl.theme.default.min.css"></link>
        <HeaderDefault></HeaderDefault>

        {/* //////HERO////// */}
        <div className="hero container-fluid">
          <img src={herolarge} alt="Photo d'une planche de Garfield" />
          <div className="container hero">
            <div className="col-md-4 presentation">
              <img src={Garfield} alt="" />
            </div>
            <button className="col-md-4 btn btn-play">
              <span >Lire</span>
            </button>
          </div>
          <div className="overlay"></div>
        </div>
        {/* //////FIN HERO////// */}

        {/* //////CATEGORY////// */}
        <div className="categorys container">
          <div className="row tuiles">
            {categoryName}
          </div>
          <div className="row btn-plus">
            <div className="col-md-2 btn btn-genre">
              <span className="plus">+ Genre</span>
            </div>
          </div>
        </div>


        <Slider sliderName='Favoris'>
          {movies.map(movie => (
            <Slider.Item movie={movie} key={movie.id}>item1</Slider.Item>
          ))}
        </Slider>

        <Slider sliderName='Titre'>
          {movies.map(movie => (
            <Slider.Item movie={movie} key={movie.id}>item1</Slider.Item>
          ))}
        </Slider>
        
        <Slider sliderName='Auteurs'>
          {movies.map(movie => (
            <Slider.Item movie={movie} key={movie.id}>item1</Slider.Item>
          ))}
        </Slider>

        <Footer></Footer>


        <script src="jquery.min.js"></script>
        <script src="owlcarousel/owl.carousel.min.js"></script>
      </div >
    );
  }
}
export default App;
