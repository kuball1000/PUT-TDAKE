package lab.backing;

import jakarta.enterprise.context.RequestScoped;
import jakarta.faces.component.html.HtmlCommandButton;
import jakarta.faces.component.html.HtmlSelectBooleanCheckbox;
import jakarta.faces.context.FacesContext;
import jakarta.faces.event.ValueChangeEvent;
import jakarta.inject.Named;

@RequestScoped
@Named
public class LoginBean {
    private String username;
    private String password;
    private HtmlSelectBooleanCheckbox acceptCheckBox;
    private HtmlCommandButton loginButton;

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String login() {
        if (username.equals(password)) {
            return "success";
        } else {
            return "failure";
        }
    }

    public HtmlSelectBooleanCheckbox getAcceptCheckBox() {
        return acceptCheckBox;
    }

    public void setAcceptCheckBox(HtmlSelectBooleanCheckbox acceptCheckBox) {
        this.acceptCheckBox = acceptCheckBox;
    }

    public HtmlCommandButton getLoginButton() {
        return loginButton;
    }

    public void setLoginButton(HtmlCommandButton loginButton) {
        this.loginButton = loginButton;
    }

    public void activateButton(ValueChangeEvent e) {
        loginButton.setDisabled(!acceptCheckBox.isSelected());

        FacesContext context = FacesContext.getCurrentInstance();
        context.renderResponse();
    }
}
