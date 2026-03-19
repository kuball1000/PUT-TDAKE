package com.example.servletsjspjstl1;

public class ColorBean {
    private String foregroundColor;
    private String backgroundColor;
    private boolean borderVisible;

    public String getForegroundColor() {
        return foregroundColor;
    }

    public void setForegroundColor(String foregroundColor) {
        this.foregroundColor = foregroundColor;
    }

    public String getBackgroundColor() {
        return backgroundColor;
    }

    public void setBackgroundColor(String backgroundColo) {
        this.backgroundColor = backgroundColo;
    }

    public boolean isBorderVisible() {
        return borderVisible;
    }

    public void setBorderVisible(boolean borderVisible) {
        this.borderVisible = borderVisible;
    }
}
