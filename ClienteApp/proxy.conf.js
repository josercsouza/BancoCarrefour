const PROXY_CONFIG = [
    {
        context: ['/api'],
        target: 'http://localhost:8080',
        secure: false,
        changeOrigin: true,
        logLevel: 'debug',
        autoRewrite: true
    }
];

module.exports = PROXY_CONFIG;
