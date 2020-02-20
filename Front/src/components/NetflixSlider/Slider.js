import React, { useState } from 'react';
import cx from 'classnames';
import SliderContext from './context'
import Content from './Content'
import SlideButton from './SlideButton'
import SliderWrapper from './SliderWrapper'
import useSliding from './useSliding'
import useSizeElement from './useSizeElement'
import './Slider.scss'

const Slider = ({ children, activeSlide, sliderName }) => {
  const [currentSlide, setCurrentSlide] = useState(activeSlide);
  const { width, elementRef } = useSizeElement();
  const {
    handlePrev,
    handleNext,
    slideProps,
    containerRef,
    hasNext,
    hasPrev
  } = useSliding(width, React.Children.count(children));

  const handleSelect = movie => {
    setCurrentSlide(movie);
  };

  const handleClose = () => {
    setCurrentSlide(null);
  };

  const contextValue = {
    onSelectSlide: handleSelect,
    onCloseSlide: handleClose,
    elementRef,
    currentSlide,
  };

  return (
    <SliderContext.Provider value={contextValue}>
      <div className="container favoris">
        <div className="row slider-row">
          <h2 className="favoris">{sliderName}</h2>
          <input className="form-control" type="text" placeholder="Search" aria-label="Search">
          </input>
          <hr className="separation"></hr>
        </div>
      </div>
      <SliderWrapper>
        <div
          className={cx('slider', { 'slider--open': currentSlide != null })}
        >
          <div ref={containerRef} className="slider__container" {...slideProps}>{children}</div>
        </div>
        {hasPrev && <SlideButton onClick={handlePrev} type="prev" />}
        {hasNext && <SlideButton onClick={handleNext} type="next" />}
      </SliderWrapper>
      {currentSlide && <Content movie={currentSlide} onClose={handleClose} />}
    </SliderContext.Provider>
  );
};

export default Slider;
