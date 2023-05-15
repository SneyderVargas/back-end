const esbuild = require('esbuild')

const { nodeExternalsPlugin } = require('esbuild-node-externals')

esbuild.build({
    entryPoints: ['./src/app.js'],
    outfile: 'dist/app.js',
    bundle: true,
    minify: true,
    platform: 'node',
    sourcemap: false,
    target: 'node16',
    plugins: [nodeExternalsPlugin()]
}).catch(() => process.exit(1))
