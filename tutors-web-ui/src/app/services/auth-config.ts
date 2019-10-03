import { UserManagerSettings } from 'oidc-client';
import { InjectionToken } from '@angular/core';

export const AUTH_CONFIG = new InjectionToken<UserManagerSettings>('auth-config');

export const OPEN_ID_AUTH_CONFIG: UserManagerSettings = {

    authority: "http://localhost:5000", // Адрес нашего IdentityServer
    client_id: "js", // должен совпадать с указанным на IdentityServer
    // Адрес страницы, на которую будет перенаправлен браузер после прохождения пользователем аутентификации
    // и получения от пользователя подтверждений - в соответствии с требованиями OpenId Connect
    redirect_uri: "http://localhost:4200/callback.html",
    // Response Type определяет набор токенов, получаемых от Authorization Endpoint
    // Данное сочетание означает, что мы используем Implicit Flow
    // http://openid.net/specs/openid-connect-core-1_0.html#Authentication
    response_type: "id_token token",
    // Получить subject id пользователя, а также поля профиля в id_token, а также получить access_token для доступа к api1 (см. наcтройки IdentityServer)
    scope: "openid profile api1",
    // Страница, на которую нужно перенаправить пользователя в случае инициированного им логаута
    post_logout_redirect_uri: "http://localhost:4200/index.html",
    // следить за состоянием сессии на IdentityServer, по умолчанию true
    monitorSession: true,
    // интервал в миллисекундах, раз в который нужно проверять сессию пользователя, по умолчанию 2000
    checkSessionInterval: 30000,
    // отзывает access_token в соответствии со стандартом https://tools.ietf.org/html/rfc7009
    revokeAccessTokenOnSignout: true,
    // допустимая погрешность часов на клиенте и серверах, нужна для валидации токенов, по умолчанию 300
    // https://github.com/IdentityModel/oidc-client-js/blob/1.3.0/src/JoseUtil.js#L95
    clockSkew: 300,
    // делать ли запрос к UserInfo endpoint для того, чтоб добавить данные в профиль пользователя
    loadUserInfo: true
}